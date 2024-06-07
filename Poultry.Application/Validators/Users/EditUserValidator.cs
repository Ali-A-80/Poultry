using FluentValidation;
using Poultry.Application.Services.Users.Commands;

namespace Poultry.Application.Validators.Users;

public class EditUserValidator : AbstractValidator<UserEditCommand>
{
    public EditUserValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("لطفا نام را وارد کنید");

        RuleFor(x => x.Password).NotEmpty().WithMessage("لطفا پسورد را وارد کنید");

        RuleFor(x => x.Email).NotEmpty().WithMessage("لطفا ایمیل را وارد کنید");

        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("لطفا شماره تلفن را وارد کنید");
    }
}
