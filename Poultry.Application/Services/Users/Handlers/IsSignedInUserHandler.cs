using MediatR;
using Microsoft.AspNetCore.Identity;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Commands;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users.Handlers;

public class IsSignedInUserHandler : IRequestHandler<UserIsSignedInCommand, ResultDto<bool>>
{
    private readonly UserManager<AppUser> _userManager;

    public IsSignedInUserHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<ResultDto<bool>> Handle(UserIsSignedInCommand request, CancellationToken cancellationToken)
    {
        var result = await _userManager.FindByNameAsync(request.Principal.Identity.Name);
        if (result is not null)
            return ResultDto<bool>.Success(true);
        return ResultDto<bool>.Success(false);
    }

}
