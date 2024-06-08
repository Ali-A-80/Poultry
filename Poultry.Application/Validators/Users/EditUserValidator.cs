using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Poultry.Application.Services.Users.Commands;
using Poultry.Domain.Entities;

namespace Poultry.Application.Validators.Users;

public class EditUserValidator : AbstractValidator<UserEditCommand>
{
    private readonly UserManager<AppUser> _userManager;

    public EditUserValidator(UserManager<AppUser> userManager)
    {
        _userManager = userManager;

        RuleFor(x => x.UserName).NotEmpty().WithMessage("لطفا نام را وارد کنید");

        RuleFor(x => x.UserName).MustAsync(UserExists).WithMessage("کاربر یافت نشد");

        RuleFor(x => x.Password).NotEmpty().WithMessage("لطفا پسورد را وارد کنید");

        RuleFor(x => x.Email).NotEmpty().WithMessage("لطفا ایمیل را وارد کنید");

        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("لطفا شماره تلفن را وارد کنید");
    }

    private async Task<bool> UserExists(string userName, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(userName);

        return user != null;
    }
}
