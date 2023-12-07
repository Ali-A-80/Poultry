using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.HealthStatuses;
using Poultry.Domain.Entities;

namespace Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthStatusController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetHealthStatuses()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPut]
        public async Task<IActionResult> EditHealthStatus(HealthStatusRequestDto healthStatus)
        {
            return HandleResult(await Mediator.Send(new Edit.Command
            {
                HealthStatus = new HealthStatus
                {
                    BodyTemprature = healthStatus.BodyTemprature,
                    HealthLevel = healthStatus.HealthLevel,
                    CheckupDate = healthStatus.CheckupDate,
                    Id = healthStatus.Id.Value
                }
            }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHealthStatus(long id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
