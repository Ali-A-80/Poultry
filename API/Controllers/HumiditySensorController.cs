﻿using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.HumiditySensors;
using Poultry.Domain.Entities;

namespace Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumiditySensorController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetHumiditySensors()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHumiditySensor(HumiditySensorRequestDto humiditySensor)
        {
            return HandleResult(await Mediator.Send(new Create.Command
            {
                HumiditySensor = new HumiditySensor
                {
                    Amount = humiditySensor.Amount,
                    HumidityStatus = humiditySensor.HumidityStatus,
                    ZoneId = humiditySensor.ZoneId
                }
            }));
        }

        [HttpPut]
        public async Task<IActionResult> EditHumiditySensor(HumiditySensorRequestDto humiditySensor)
        {
            return HandleResult(await Mediator.Send(new Edit.Command
            {
                HumiditySensor = new HumiditySensor
                {
                    Id = humiditySensor.Id.Value,
                    Amount = humiditySensor.Amount,
                    HumidityStatus = humiditySensor.HumidityStatus
                }
            }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHumiditySensor(long id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
