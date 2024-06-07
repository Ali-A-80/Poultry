using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.VentilationSensors.Commands;
using Poultry.Application.Services.VentilationSensors.Dtos;
using Poultry.Application.Validators;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.VentilationSensors.Handlers;

public class EditVentilationSensorHandler : IRequestHandler<VentilationSensorEditCommand, ResultDto<VentilationSensorResponseDto>>
{

    private readonly DatabaseContext _context;

    public EditVentilationSensorHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<VentilationSensorResponseDto>> Handle(VentilationSensorEditCommand request, CancellationToken cancellationToken)
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
