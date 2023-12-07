using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.FoodServices
{
    public class Edit
    {
        public class Command : IRequest<ResultDto<FoodServiceResponseDto>>
        {
            public FoodService FoodService { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResultDto<FoodServiceResponseDto>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<FoodServiceResponseDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                #region Validation
                var validation = new FoodServiceValidator();
                var validationResult = await validation.ValidateAsync(request.FoodService, cancellationToken);

                if (!validationResult.IsValid)
                {
                    var errors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                    return ResultDto<FoodServiceResponseDto>.Failure(errors);
                }
                #endregion

                var foodService = await _context.FoodServices.FirstOrDefaultAsync(x => x.Id == request.FoodService.Id , cancellationToken);

                if (foodService is null)
                    return ResultDto<FoodServiceResponseDto>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

                foodService.Amount = request.FoodService.Amount;
                foodService.FoodType = request.FoodService.FoodType;
                foodService.UpdateTime = DateTime.Now;

                _context.Update(foodService);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<FoodServiceResponseDto>.Success(new FoodServiceResponseDto(foodService));
            }
        }
    }

}
