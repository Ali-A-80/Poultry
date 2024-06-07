using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Commands;
using Poultry.Application.Services.Users.Dtos;


namespace Endpoint.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(UserCreateLoginRequestDto request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var command = new UserCreateCommand
        {
            Username = request.Username,
            Password = request.Password
        };

        var userCreateResponse = await Mediator.Send(command);

        var userTokenServiceResponse = await Mediator.Send(new UserTokenServiceCommand { AppUser = userCreateResponse.Data });

        return HandleResult(userTokenServiceResponse);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserCreateLoginRequestDto request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var userCreateLoginResponse = await Mediator.Send(new UserLoginCommand { UserRequest = request });

        if (userCreateLoginResponse.Data is null)
            return NotFound("کاربر یافت نشد");

        var userTokenServiceResponse = await Mediator.Send(new UserTokenServiceCommand { AppUser = userCreateLoginResponse.Data });

        return HandleResult(userTokenServiceResponse);
    }

    [HttpGet("logout")]

    public async Task<IActionResult> Logout()
    {
        var response = await Mediator.Send(new UserLogoutCommand { });

        return HandleResult(response);
    }

    [HttpGet("issignedin")]
    public async Task<IActionResult> IsSignedIn()
    {
        var command = new UserValidateTokenServiceCommand { Token = Request.Headers["Authorization"]! };

        var userValidateTokenServiceResponse = await Mediator.Send(command);

        if (userValidateTokenServiceResponse.Data is null)
        {
            return BadRequest();
        }
        else
        {
            var userIsSignedInResult = await Mediator.Send(new UserIsSignedInCommand { Principal = userValidateTokenServiceResponse.Data });
            return Ok(userIsSignedInResult.Data);
        }

    }

    [HttpGet("getuserinfo")]
    public async Task<IActionResult> GetUserInfo()
    {
        var command = new UserValidateTokenServiceCommand { Token = Request.Headers["Authorization"]! };

        var userValidateTokenService = await Mediator.Send(command);

        if (userValidateTokenService.Data is null)
            return BadRequest();

        var userDetail = await Mediator.Send(new UserDetailCommand { Principal = userValidateTokenService.Data });

        return HandleResult(userDetail);
    }

    [HttpPut("edituserinfo")]
    public async Task<IActionResult> EditUserInfo(UserEditRequestDto request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var userValidateTokenServiceCommand = new UserValidateTokenServiceCommand { Token = Request.Headers["Authorization"]! };

        var userValidateTokenServiceResponse = await Mediator.Send(userValidateTokenServiceCommand);

        if (userValidateTokenServiceResponse.Data is null)
            return BadRequest();

        var editedUserCommand = new UserEditCommand
        {
            Principal = userValidateTokenServiceResponse.Data,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password,
            UserName = request.UserName
        };

        var editedUserResponse = await Mediator.Send(editedUserCommand);

        var userTokenServiceCommand = new UserTokenServiceCommand { AppUser = editedUserResponse.Data };

        var result = await Mediator.Send(userTokenServiceCommand);

        return HandleResult(ResultDto<UserEditResponseDto>.Success(new UserEditResponseDto(result.Data)));
    }

}
