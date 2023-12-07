using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.Chickens
{
    public class Edit
    {
        public class Command : IRequest<ResultDto<ChickenResponseDto>>
        {
            public Chicken Chicken { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResultDto<ChickenResponseDto>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }

            public async Task<ResultDto<ChickenResponseDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                #region Validation
                var validation = new ChickenValidator();
                var validationResult = await validation.ValidateAsync(request.Chicken, cancellationToken);

                if (!validationResult.IsValid)
                {
                    var errors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                    return ResultDto<ChickenResponseDto>.Failure(errors);
                }

                #endregion

                var chicken = await _context.Chickens.Include(x =>x.HealthStatus).FirstOrDefaultAsync(x => x.Id == request.Chicken.Id , cancellationToken);
                if (chicken is null)
                    return ResultDto<ChickenResponseDto>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

                chicken.Age = request.Chicken.Age;
                chicken.ChickenType = request.Chicken.ChickenType;
                chicken.Gender = request.Chicken.Gender;
                chicken.HealthStatus = request.Chicken.HealthStatus;
                chicken.LayingRate = request.Chicken.LayingRate;
                chicken.Weight = request.Chicken.Weight;
                chicken.UpdateTime = DateTime.Now;

                _context.Chickens.Update(chicken);
                _context.SaveChanges();

                return ResultDto<ChickenResponseDto>.Success(new ChickenResponseDto(chicken));
            }
        }
    }
}
