using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.FoodServices
{
    public class Create
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

                var foodService = new FoodService()
                {
                    Amount = request.FoodService.Amount,
                    FoodType = request.FoodService.FoodType
                };

                await _context.FoodServices.AddAsync(foodService, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<FoodServiceResponseDto>.Success(new FoodServiceResponseDto(foodService));
            }
        }

    }
}
