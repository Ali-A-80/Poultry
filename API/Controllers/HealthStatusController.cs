using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.HealthStatuses.Commands;
using Poultry.Application.Services.HealthStatuses.Dtos;
using Poultry.Application.Services.HealthStatuses.Queries;

namespace Endpoint.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthStatusController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetHealthStatuses()
    {
        var response = await Mediator.Send(new HealthStatusListQuery());

        return HandleResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> EditHealthStatus(EditHealthStatusRequestDto healthStatus)
    {
        var command = new HealthStatusEditCommand
        {
            BodyTemprature = healthStatus.BodyTemprature,
            HealthLevel = healthStatus.HealthLevel,
            CheckupDate = healthStatus.CheckupDate,
            Id = healthStatus.Id
        };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteHealthStatus(long id)
    {
        var command = new HealthStatusDeleteCommand { Id = id };

        var response = await Mediator.Send(command);

        return HandleResult(response);
    }
}
