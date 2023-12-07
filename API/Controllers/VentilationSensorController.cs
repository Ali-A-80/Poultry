using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.VentilationSensors;
using Poultry.Domain.Entities;

namespace Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentilationSensorController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetVentilationSensors()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateVentilationSensor(VentilationSensorRequestDto ventilationSensor)
        {
            return HandleResult(await Mediator.Send(new Create.Command 
            { 
                VentilationSensor = new VentilationSensor
                {
                    AirFlow = ventilationSensor.AirFlow,
                    VentilationStatus = ventilationSensor.VentilationStatus,
                    ZoneId = ventilationSensor.ZoneId
                } 
            }));
        }

        [HttpPut]
        public async Task<IActionResult> EditVentilationSensor(VentilationSensorRequestDto ventilationSensor)
        {
            return HandleResult(await Mediator.Send(new Edit.Command 
            { 
                VentilationSensor = new VentilationSensor
                {
                    VentilationStatus = ventilationSensor.VentilationStatus,
                    AirFlow = ventilationSensor.AirFlow,
                    Id = ventilationSensor.Id.Value
                } 
            }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVentilationSensor(long id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
