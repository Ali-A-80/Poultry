using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.Users;
using Poultry.Domain.Entities;


namespace Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestDto request)
        {
            var user = await Mediator.Send(new Create.Command { UserRequest = request });
            return HandleResult(await Mediator.Send(new TokenService.Command { AppUser = user.Data/*, Roles = request.Roles */}));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login (UserRequestDto request)
        {
            var user = await Mediator.Send(new Login.Command { UserRequest = request });
            return HandleResult(await Mediator.Send(new TokenService.Command { AppUser = user.Data}));
        }

        [HttpGet("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            return HandleResult( await Mediator.Send(new Logout.Command { }));
        }

        [HttpGet("issignedin")]
        public async Task<IActionResult> IsSignedIn()
        {
            string temp = Request.Headers["Authorization"];
            var user = await Mediator.Send(new ValidateTokenService.Command{ Token = Request.Headers["Authorization"] });
            if (user.Data is null)
                return BadRequest();
            else
            {
                var result = await Mediator.Send(new IsSignedIn.Command { Principal = user.Data });
                return Ok(result.Data);
            }
            
        }

        #region RefreshToken
        //[HttpPost]
        //public async Task<IActionResult> RefreshToken(string token)
        //{
        //    var user = await Mediator.Send(new ReTokenService.Command { Token = token });
        //    return HandleResult(await Mediator.Send(new TokenService.Command { AppUser = user.Data }));
        //}

        #endregion

        #region MyRegion
        //[Authorize]
        //[HttpGet("get-current-user")]
        //public ActionResult<ResultDto<CurrentUserResponseDto>> GetCurrentUser()
        //{
        //    var userName = User.FindFirstValue(ClaimTypes.Name);
        //    var email = User.FindFirstValue(ClaimTypes.Email);
        //    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    List<string> roles = new();
        //    foreach (var item in User.Claims.Where(p => p.Type.EndsWith("role")))
        //    {
        //        roles.Add(item.Value);
        //    }

        //    return Ok(ResultDto<CurrentUserResponseDto>.Success(new CurrentUserResponseDto
        //    {
        //        Email = email,
        //        Roles = roles,
        //        Id = id,
        //        UserName = userName
        //    }));
        //}

        #endregion
    }
}
