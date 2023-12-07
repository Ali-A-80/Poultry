using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.VentilationSensors
{
    public class Edit
    {
        public class Command : IRequest<ResultDto<VentilationSensorResponseDto>>
        {
            public VentilationSensor VentilationSensor { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResultDto<VentilationSensorResponseDto>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<VentilationSensorResponseDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                #region Validation
                var validation = new VentilationSensorValidator();
                var validationResult = await validation.ValidateAsync(request.VentilationSensor, cancellationToken);

                if (!validationResult.IsValid)
                {
                    var errors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                    return ResultDto<VentilationSensorResponseDto>.Failure(errors);
                }
                #endregion

                var ventilationSensor = await _context.VentilationSensors.FirstOrDefaultAsync(x => x.Id == request.VentilationSensor.Id, cancellationToken);

                if (ventilationSensor is null)
                    return ResultDto<VentilationSensorResponseDto>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

                ventilationSensor.AirFlow = ventilationSensor.AirFlow;
                ventilationSensor.VentilationStatus = ventilationSensor.VentilationStatus;
                ventilationSensor.UpdateTime = DateTime.Now;

                _context.VentilationSensors.Update(ventilationSensor);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<VentilationSensorResponseDto>.Success(new VentilationSensorResponseDto(ventilationSensor));
            }
        }
    }
}
