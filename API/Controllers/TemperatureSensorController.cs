using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.TemperatureSensors.Commands;
using Poultry.Application.Services.TemperatureSensors.Dtos;
using Poultry.Application.Services.TemperatureSensors.Queries;

namespace Endpoint.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TemperatureSensorController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetTemperatureSensors()
    {
        var response = await Mediator.Send(new TemperatureSensorListQuery());

        return HandleResult(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTemperatureSensor(CreateTemperatureSensorRequestDto temperatureSensor)
    {
        ArgumentNullException.ThrowIfNull(temperatureSensor);

        var command = new TemperatureSensorCreateCommand
        {
            Amount = temperatureSensor.Amount,
            TemperatureStatus = temperatureSensor.TemperatureStatus,
            ZoneId = temperatureSensor.ZoneId
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> EditTemperatureSensor(EditTemperatureSensorRequestDto temperatureSensor)
    {
        ArgumentNullException.ThrowIfNull(temperatureSensor);

        var command = new TemperatureSensorEditCommand
        {
            TemperatureStatus = temperatureSensor.TemperatureStatus,
            Id = temperatureSensor.Id,
            Amount = temperatureSensor.Amount

        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTemperatureSensor(long id)
    {
        var response = await Mediator.Send(new TemperatureSensorDeleteCommand { Id = id });

        return HandleResult(response);
    }
}
