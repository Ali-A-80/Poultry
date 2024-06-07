using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.HumiditySensors.Commands;
using Poultry.Application.Services.HumiditySensors.Dtos;
using Poultry.Application.Services.HumiditySensors.Queries;
using Poultry.Domain.Entities;

namespace Endpoint.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HumiditySensorController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetHumiditySensors()
    {
        var response = await Mediator.Send(new HumiditySensorListQuery());

        return HandleResult(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHumiditySensor(CreateHumiditySensorRequestDto humiditySensor)
    {
        ArgumentNullException.ThrowIfNull(humiditySensor);

        var command = new HumiditySensorCreateCommand
        {
            Amount = humiditySensor.Amount,
            HumidityStatus = humiditySensor.HumidityStatus,
            ZoneId = humiditySensor.ZoneId
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> EditHumiditySensor(EditHumiditySensorRequestDto humiditySensor)
    {
        ArgumentNullException.ThrowIfNull(humiditySensor);

        var command = new HumiditySensorEditCommand
        {
            HumiditySensor = new HumiditySensor
            {
                Id = humiditySensor.Id,
                Amount = humiditySensor.Amount,
                HumidityStatus = humiditySensor.HumidityStatus
            }
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteHumiditySensor(long id)
    {
        var response = await Mediator.Send(new HumiditySensorDeleteCommand { Id = id });

        return HandleResult(response);
    }
}
