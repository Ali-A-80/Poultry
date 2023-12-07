using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.TemperatureSensors
{
    public class Create
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

                var zone = await _context.Zones.Include(x => x.Weather).AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.TemperatureSensor.ZoneId, cancellationToken);

                if (zone is null)
                    return ResultDto<TemperatureSensorResponseDto>.Failure(new List<string> { "ناحیه مورد نظر یافت نشد" });

                var temperatureSensor = new TemperatureSensor()
                {
                    Amount = request.TemperatureSensor.Amount,
                    TemperatureStatus = request.TemperatureSensor.TemperatureStatus,
                    ZoneId = zone.Id
                };

                await _context.TemperatureSensors.AddAsync(temperatureSensor, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<TemperatureSensorResponseDto>.Success(new TemperatureSensorResponseDto(temperatureSensor));
            }
        }
    }
}
