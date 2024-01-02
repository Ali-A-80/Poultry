using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.VentilationSensors
{
    public class Delete
    {
        public class Command : IRequest<ResultDto<Unit>>
        {
            public long Id { get; set; }
        }

        public class VentilationSensorDeleteValidator : AbstractValidator<Command>
        {
            public VentilationSensorDeleteValidator()
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
                var validation = new VentilationSensorDeleteValidator();
                var validationResult = await validation.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                    return ResultDto<Unit>.Failure(new List<string> { $"{validationResult.Errors[0].ErrorMessage}" });
                #endregion

                var ventilationSensor = await _context.VentilationSensors.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (ventilationSensor is null)
                    return ResultDto<Unit>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

                ventilationSensor.IsRemoved = true;
                ventilationSensor.RemoveTime = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<Unit>.Success(Unit.Value);
            }
        }
    }
}
