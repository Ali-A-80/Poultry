using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.FoodServices.Commands;
using Poultry.Application.Services.FoodServices.Dtos;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.FoodServices;

namespace Poultry.Application.Services.FoodServices.Handlers;

public class CreateFoodServiceHandler : IRequestHandler<FoodServiceCreateCommand, ResultDto<FoodServiceResponseDto>>
{

    private readonly IFoodServiceCommandRepository _foodServiceCommandRepository;

    public CreateFoodServiceHandler(IFoodServiceCommandRepository foodServiceCommandRepository)
    {
        _foodServiceCommandRepository = foodServiceCommandRepository;
    }

    public async Task<ResultDto<FoodServiceResponseDto>> Handle(FoodServiceCreateCommand request, CancellationToken cancellationToken)
    {

        var foodService = new FoodService()
        {
            Amount = request.Amount,
            FoodType = request.FoodType
        };

        await _foodServiceCommandRepository.AddFoodService(foodService, cancellationToken);

        return ResultDto<FoodServiceResponseDto>.Success(new FoodServiceResponseDto(foodService));
    }


}
