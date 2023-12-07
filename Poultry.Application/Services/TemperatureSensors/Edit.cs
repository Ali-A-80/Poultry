using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.TemperatureSensors
{
    public class Edit
    {
        public class Command : IRequest<ResultDto<TemperatureSensorResponseDto>>
        {
            public TemperatureSensor TemperatureSensor { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResultDto<TemperatureSensorResponseDto>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<TemperatureSensorResponseDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                #region Validation
                var validation = new TemperatureSensorValidator();
                var validationResult = await validation.ValidateAsync(request.TemperatureSensor, cancellationToken);

                if (!validationResult.IsValid)
                {
                    var errors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                    return ResultDto<TemperatureSensorResponseDto>.Failure(errors);
                }
                #endregion

                var temperatureSensor = await _context.TemperatureSensors.FirstOrDefaultAsync(x => x.Id == request.TemperatureSensor.Id, cancellationToken);

                if (temperatureSensor is null)
                    return ResultDto<TemperatureSensorResponseDto>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

                temperatureSensor.Amount = temperatureSensor.Amount;
                temperatureSensor.TemperatureStatus = temperatureSensor.TemperatureStatus;
                temperatureSensor.UpdateTime = DateTime.Now;

                _context.TemperatureSensors.Update(temperatureSensor);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<TemperatureSensorResponseDto>.Success(new TemperatureSensorResponseDto(temperatureSensor));
            }
        }
    }
}
