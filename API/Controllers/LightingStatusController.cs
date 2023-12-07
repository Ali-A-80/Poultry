using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.LightingStatuses;
using Poultry.Domain.Entities;

namespace Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LightingStatusController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetLightingStatuses()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPut]
        public async Task<IActionResult> EditLightingStatus(LightingStatusRequestDto lightingStatus)
        {
            return HandleResult(await Mediator.Send(new Edit.Command
            {
                LightingStatus = new LightingStatus
                {
                    Id = lightingStatus.Id.Value,
                    Amount = lightingStatus.Amount,
                    LightingStatusType = lightingStatus.LightingStatusType
                }
            }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLightingStatus(long id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
