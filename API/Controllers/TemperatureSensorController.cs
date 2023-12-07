using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.TemperatureSensors;
using Poultry.Domain.Entities;

namespace Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureSensorController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetTemperatureSensors()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemperatureSensor(TemperatureSensorRequestDto temperatureSensor)
        {
            return HandleResult(await Mediator.Send(new Create.Command
            {
                TemperatureSensor = new TemperatureSensor
                {
                    Amount = temperatureSensor.Amount,
                    TemperatureStatus = temperatureSensor.TemperatureStatus,
                    ZoneId = temperatureSensor.ZoneId
                }
            }));
        }

        [HttpPut]
        public async Task<IActionResult> EditTemperatureSensor(TemperatureSensorRequestDto temperatureSensor)
        {
            return HandleResult(await Mediator.Send(new Edit.Command
            {
                TemperatureSensor = new TemperatureSensor
                {
                    TemperatureStatus = temperatureSensor.TemperatureStatus,
                    Id = temperatureSensor.Id.Value,
                    Amount = temperatureSensor.Amount
                }
            }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTemperatureSensor(long id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
