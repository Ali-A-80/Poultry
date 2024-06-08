using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Poultry.Application.Services.Users.Commands;
using Poultry.Domain.Entities;

namespace Poultry.Application.Validators.Users;

public class DetailUserValidator : AbstractValidator<UserDetailCommand>
{
    private readonly UserManager<AppUser> _userManager;

    public DetailUserValidator(UserManager<AppUser> userManager)
    {
        _userManager = userManager;

        RuleFor(x => x.Principal.Identity!.Name).MustAsync(UserExists!).WithMessage("کاربر یافت نشد");
    }

    private async Task<bool> UserExists(string userName, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(userName);

        return user != null;
    }
}
