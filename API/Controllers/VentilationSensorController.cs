using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.VentilationSensors.Commands;
using Poultry.Application.Services.VentilationSensors.Dtos;
using Poultry.Application.Services.VentilationSensors.Queries;

namespace Endpoint.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VentilationSensorController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetVentilationSensors()
    {
        return HandleResult(await Mediator.Send(new VentilationSensorListQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateVentilationSensor(CreateVentilationSensorRequestDto ventilationSensor)
    {
        ArgumentNullException.ThrowIfNull(ventilationSensor);

        var command = new VentilationSensorCreateCommand
        {
            AirFlow = ventilationSensor.AirFlow,
            VentilationStatus = ventilationSensor.VentilationStatus,
            ZoneId = ventilationSensor.ZoneId
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> EditVentilationSensor(EditVentilationSensorRequestDto ventilationSensor)
    {
        ArgumentNullException.ThrowIfNull(ventilationSensor);

        var command = new VentilationSensorEditCommand
        {
            VentilationStatus = ventilationSensor.VentilationStatus,
            AirFlow = ventilationSensor.AirFlow,
            Id = ventilationSensor.Id

        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteVentilationSensor(long id)
    {
        return HandleResult(await Mediator.Send(new VentilationSensorDeleteCommand { Id = id }));
    }
}
