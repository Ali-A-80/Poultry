using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.LightingStatuses.Commands;
using Poultry.Application.Services.LightingStatuses.Dtos;
using Poultry.Application.Services.LightingStatuses.Queries;
using Poultry.Domain.Entities;

namespace Endpoint.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LightingStatusController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetLightingStatuses()
    {
        var response = await Mediator.Send(new LightingStatusListQuery());

        return HandleResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> EditLightingStatus(EditLightingStatusRequestDto lightingStatus)
    {
        ArgumentNullException.ThrowIfNull(lightingStatus);

        var command = new LightingStatusEditCommand
        {
            Id = lightingStatus.Id,
            Amount = lightingStatus.Amount,
            LightingStatusType = lightingStatus.LightingStatusType
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLightingStatus(long id)
    {
        var response = await Mediator.Send(new LightingStatusDeleteCommand { Id = id });

        return HandleResult(response);
    }
}
