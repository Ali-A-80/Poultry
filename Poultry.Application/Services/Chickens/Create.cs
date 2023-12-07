using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.Chickens
{
    public class Create
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

                var chicken = new Chicken
                {
                    Age = request.Chicken.Age,
                    ChickenType = request.Chicken.ChickenType,
                    Gender = request.Chicken.Gender,
                    HealthStatus = request.Chicken.HealthStatus,
                    LayingRate = request.Chicken.LayingRate,
                    Weight = request.Chicken.Weight
                };

                var rand = new Random();

                var healthStatus = new HealthStatus
                {
                    Chicken = chicken,
                    BodyTemprature = rand.Next(36,43),
                    CheckupDate = DateTime.Now,
                    HealthLevel = HealthLevel.Healthy                    
                };

                await _context.Chickens.AddAsync(chicken, cancellationToken);
                await _context.HealthStatuses.AddAsync(healthStatus, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<ChickenResponseDto>.Success(new ChickenResponseDto(chicken));
            }
        }
    }
}
