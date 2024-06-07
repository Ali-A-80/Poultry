using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.VentilationSensors.Commands;
using Poultry.Application.Services.VentilationSensors.Dtos;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.VentilationSensors.Handlers;

public class CreateVentilationSensorHandler : IRequestHandler<VentilationSensorCreateCommand, ResultDto<VentilationSensorResponseDto>>
{

    private readonly DatabaseContext _context;

    public CreateVentilationSensorHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<VentilationSensorResponseDto>> Handle(VentilationSensorCreateCommand request, CancellationToken cancellationToken)
    {
        #region Validation
        var validation = new CreateVentilationSensorValidator();
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

        var zone = await _context.Zones.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.VentilationSensor.ZoneId, cancellationToken);

        if (zone is null)
            return ResultDto<VentilationSensorResponseDto>.Failure(new List<string> { "ناحیه مورد نظر یافت نشد" });

        var ventilationSensor = new VentilationSensor()
        {
            AirFlow = request.VentilationSensor.AirFlow,
            VentilationStatus = request.VentilationSensor.VentilationStatus,
            ZoneId = zone.Id
        };

        await _context.VentilationSensors.AddAsync(ventilationSensor, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultDto<VentilationSensorResponseDto>.Success(new VentilationSensorResponseDto(ventilationSensor));
    }

}
