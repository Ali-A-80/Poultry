﻿using FluentValidation;
using Poultry.Application.Services.Chickens.Commands;

namespace Poultry.Application.Validators.Chickens;

public class CreateChickenValidator : AbstractValidator<CreateChickenCommand>
{
    public CreateChickenValidator()
    {

        RuleFor(x => x.Gender).NotNull().WithMessage("لطفا جنسیت را وارد کنید");

        RuleFor(x => x.Age).NotNull().WithMessage("لطفا مقدار سن را وارد کنید")
            .Must(x => x >= 0 && x <= 255).WithMessage("محدوده سنی را به درستی وارد کنید");

        RuleFor(x => x.ChickenType).IsInEnum().WithMessage("لطفا نوع طیر را به درستی وارد کنید");

        RuleFor(x => x.Weight).NotNull().WithMessage("لطفا وزن را وارد کنید");

        RuleFor(x => x.LayingRate).NotNull().WithMessage("لطفا نرخ تخم گذاری را وارد کنید");

    }
}