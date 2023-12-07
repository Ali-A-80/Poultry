using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Core;

namespace Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(ResultDto<T> result)
        {
            if (result == null) return NotFound();

            if (result.IsSuccess && result.Data != null)
                return Ok(result);

            if (result.IsSuccess && result.Data == null)
                return NotFound();

            return BadRequest(result);
        }
    }
}
