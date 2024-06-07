using MediatR;
using Microsoft.AspNetCore.Identity;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Commands;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users.Handlers;

public partial class EditUserHandler : IRequestHandler<UserEditCommand, ResultDto<AppUser>>
{

    private readonly UserManager<AppUser> _userManager;

    public EditUserHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<ResultDto<AppUser>> Handle(UserEditCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Principal.Identity.Name);

        if (user is null)
            return ResultDto<AppUser>.Failure(new List<string> { "کاربر یافت نشد" });

        user.UserName = request.UserEdit.UserName;
        user.Email = request.UserEdit.Email;
        user.PhoneNumber = request.UserEdit.PhoneNumber;
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        await _userManager.ResetPasswordAsync(user, token, request.UserEdit.Password);
        await _userManager.UpdateAsync(user);

        return ResultDto<AppUser>.Success(user);
    }

}
