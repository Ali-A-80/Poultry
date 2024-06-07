using FluentValidation;
using Poultry.Application.Services.Users.Commands;

namespace Poultry.Application.Validators.Users;

public class CreateUserValidator : AbstractValidator<UserCreateCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("لطفا نام را وارد کنید");

        RuleFor(x => x.Password).NotEmpty().WithMessage("لطفا پسورد را وارد کنید");
    }
}
