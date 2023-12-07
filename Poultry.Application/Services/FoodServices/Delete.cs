using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.FoodServices
{
    public class Delete
    {
        public class Command : IRequest<ResultDto<Unit>>
        {
            public long Id { get; set; }
        }

        public class FoodServiceDeleteValidator : AbstractValidator<Command>
        {
            public FoodServiceDeleteValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("شناسه را وارد کنید");
            }
        }

        public class Handler : IRequestHandler<Command, ResultDto<Unit>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                #region Validation
                var validation = new FoodServiceDeleteValidator();
                var validationResult = await validation.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                    return ResultDto<Unit>.Failure(new List<string> { $"{validationResult.Errors[0].ErrorMessage}" });
                #endregion

                var foodService = await _context.FoodServices.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (foodService is null)
                    return ResultDto<Unit>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

                foodService.IsRemoved = true;
                foodService.RemoveTime = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<Unit>.Success(Unit.Value);

            }
        }
    }
}
