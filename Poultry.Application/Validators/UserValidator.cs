﻿using FluentValidation;
using Poultry.Application.Services.Users;

namespace Poultry.Application.EntityValidators
{
    public class UserValidator : AbstractValidator<UserCreateLoginRequestDto>
    {
        public UserValidator()
        {
            //RuleFor(x => x.Email).NotEmpty().WithMessage("لطفا ایمیل را وارد کنید")
            //    .EmailAddress().WithMessage("فرمت ایمیل صحیح نیست");

            RuleFor(x => x.Username).NotEmpty().WithMessage("لطفا نام را وارد کنید");

            RuleFor(x => x.Password).NotEmpty().WithMessage("لطفا پسورد را وارد کنید");
        }
    }

}
