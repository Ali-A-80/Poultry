using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.FoodServices.Commands;
using Poultry.Application.Services.FoodServices.Dtos;
using Poultry.Domain.Repositories.FoodServices;

namespace Poultry.Application.Services.FoodServices.Handlers;

public class EditFoodServiceHandler : IRequestHandler<FoodServiceEditCommand, ResultDto<FoodServiceResponseDto>>
{

    private readonly IFoodServiceCommandRepository _foodServiceCommandRepository;

    public EditFoodServiceHandler(IFoodServiceCommandRepository foodServiceCommandRepository)
    {
        _foodServiceCommandRepository = foodServiceCommandRepository;
    }
    public async Task<ResultDto<FoodServiceResponseDto>> Handle(FoodServiceEditCommand request, CancellationToken cancellationToken)
    {
        var foodService = await _foodServiceCommandRepository.GetById(request.Id, cancellationToken);

        foodService.Amount = request.Amount;
        foodService.FoodType = request.FoodType;
        foodService.UpdateTime = DateTime.Now;

        await _foodServiceCommandRepository.UpdateFoodService(foodService, cancellationToken);

        return ResultDto<FoodServiceResponseDto>.Success(new FoodServiceResponseDto(foodService));
    }

}
