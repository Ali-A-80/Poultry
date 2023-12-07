using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.Zones;
using Poultry.Domain.Entities;

namespace Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetZones()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateZone(ZoneRequestDto zone)
        {
            return HandleResult(await Mediator.Send(new Create.Command 
            { 
                Zone = new Zone
                {
                    ZoneType = zone.ZoneType
                } 
            }));
        }

        [HttpPut]
        public async Task<IActionResult> EditZone(ZoneRequestDto zone)
        {
            return HandleResult(await Mediator.Send(new Edit.Command 
            { 
                Zone = new Zone
                {
                    Id = zone.Id.Value,
                    ZoneType = zone.ZoneType
                } 
            }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteZone(long id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
