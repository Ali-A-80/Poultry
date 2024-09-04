using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.FoodServices.Commands;
using Poultry.Application.Services.FoodServices.Dtos;
using Poultry.Application.Services.FoodServices.Queries;

namespace Endpoint.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodServiceController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetFoodServices()
    {
        var response = await Mediator.Send(new FoodServiceListQuery());

        return HandleResult(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFoodService(CreateFoodServiceRequestDto foodService)
    {
        ArgumentNullException.ThrowIfNull(foodService);

        var command = new FoodServiceCreateCommand
        {
            FoodType = foodService.FoodType,
            Amount = foodService.Amount,
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> EditFoodService(EditFoodServiceRequestDto foodService)
    {
        ArgumentNullException.ThrowIfNull(foodService);

        var command = new FoodServiceEditCommand
        {
            Id = foodService.Id,
            Amount = foodService.Amount,
            FoodType = foodService.FoodType
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFoodService(long id)
    {
        var response = await Mediator.Send(new FoodServiceDeleteCommand { Id = id });

        return HandleResult(response);
    }
}
