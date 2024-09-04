using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.FoodServices.Commands;
using Poultry.Domain.Repositories.FoodServices;

namespace Poultry.Application.Services.FoodServices.Handlers;

public class DeleteFoodServiceHandler : IRequestHandler<FoodServiceDeleteCommand, ResultDto<Unit>>
{

    private readonly IFoodServiceCommandRepository _foodServiceCommandRepository;

    public DeleteFoodServiceHandler(IFoodServiceCommandRepository foodServiceCommandRepository)
    {
        _foodServiceCommandRepository = foodServiceCommandRepository;
    }

    public async Task<ResultDto<Unit>> Handle(FoodServiceDeleteCommand request, CancellationToken cancellationToken)
    {
        var foodService = await _foodServiceCommandRepository.GetById(request.Id, cancellationToken);

        foodService.IsRemoved = true;
        foodService.RemoveTime = DateTime.Now;

        await _foodServiceCommandRepository.UpdateFoodService(foodService, cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);

    }

}
