using MediatR;
using Microsoft.AspNetCore.Identity;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Commands;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users.Handlers;

public class LogoutUserHandler : IRequestHandler<UserLogoutCommand, ResultDto<Unit>>
{
    private readonly SignInManager<AppUser> _signInManager;

    public LogoutUserHandler(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }
    public async Task<ResultDto<Unit>> Handle(UserLogoutCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
        return ResultDto<Unit>.Success(Unit.Value);
    }

}
