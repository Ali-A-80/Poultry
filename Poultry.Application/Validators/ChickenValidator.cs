using FluentValidation;
using Poultry.Domain.Entities;

namespace Poultry.Application.Validators
{
    public class ChickenValidator : AbstractValidator<Chicken>
    {
        public ChickenValidator()
        {

            RuleFor(x => x.Gender).NotEmpty().WithMessage("لطفا جنسیت را وارد کنید");

            RuleFor(x => x.Age).NotEmpty().WithMessage("لطفا مقدار سن را وارد کنید")
                .Must(x => x >= 0 && x <= 255).WithMessage("محدوده سنی را به درستی وارد کنید");

            RuleFor(x => x.ChickenType).IsInEnum().WithMessage("لطفا نوع طیر را به درستی وارد کنید");

            RuleFor(x => x.Weight).NotEmpty().WithMessage("لطفا وزن را وارد کنید");

        }
    }
}
