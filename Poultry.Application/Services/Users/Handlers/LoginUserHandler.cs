using MediatR;
using Microsoft.AspNetCore.Identity;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Commands;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users.Handlers;

public class LoginUserHandler : IRequestHandler<UserLoginCommand, ResultDto<AppUser>>
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public LoginUserHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    public async Task<ResultDto<AppUser>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInManager
            .PasswordSignInAsync(request.UserRequest.Username, request.UserRequest.Password, false, false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(request.UserRequest.Username);
            await _signInManager.SignInAsync(user, isPersistent: false);
            return ResultDto<AppUser>.Success(user);
        }
        return ResultDto<AppUser>.Failure(new List<string> { "ورود ناموفق" });

    }

}
