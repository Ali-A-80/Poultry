using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.Chickens.Commands;
using Poultry.Application.Services.Chickens.Dtos;
using Poultry.Application.Services.Chickens.Queries;

namespace Endpoint.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChickenController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetChickens()
    {
        var response = await Mediator.Send(new ChickenListQuery());

        return HandleResult(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateChicken(CreateChickenRequestDto chicken)
    {
        ArgumentNullException.ThrowIfNull(chicken);

        var command = new CreateChickenCommand
        {
            Age = chicken.Age,
            ChickenType = chicken.ChickenType,
            Gender = chicken.Gender,
            LayingRate = chicken.LayingRate,
            Weight = chicken.Weight
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> EditChicken(EditChickenRequestDto chicken)
    {
        ArgumentNullException.ThrowIfNull(chicken);

        var command = new EditChickenCommand
        {
            Id = chicken.Id,
            Age = chicken.Age,
            ChickenType = chicken.ChickenType,
            Gender = chicken.Gender,
            LayingRate = chicken.LayingRate,
            Weight = chicken.Weight
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteChicken(long id)
    {
        var command = new DeleteChickenCommand { Id = id };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }
}
