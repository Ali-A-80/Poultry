using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.Zones.Commands;
using Poultry.Application.Services.Zones.Dtos;
using Poultry.Application.Services.Zones.Queries;

namespace Endpoint.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ZoneController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetZones()
    {
        return HandleResult(await Mediator.Send(new ZoneListQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateZone(CreateZoneRequestDto zone)
    {
        var command = new ZoneCreateCommand
        {
            ZoneType = zone.ZoneType
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> EditZone(EditZoneRequestDto zone)
    {
        var command = new ZoneEditCommand
        {
            Id = zone.Id,
            ZoneType = zone.ZoneType
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteZone(long id)
    {
        var response = await Mediator.Send(new ZoneDeleteCommand { Id = id });

        return HandleResult(response);
    }
}
