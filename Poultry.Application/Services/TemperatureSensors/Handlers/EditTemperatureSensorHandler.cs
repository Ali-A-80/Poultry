using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.TemperatureSensors.Commands;
using Poultry.Application.Services.TemperatureSensors.Dtos;
using Poultry.Application.Validators;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.TemperatureSensors.Handlers;

public class EditTemperatureSensorHandler : IRequestHandler<TemperatureSensorEditCommand, ResultDto<TemperatureSensorResponseDto>>
{

    private readonly DatabaseContext _context;

    public EditTemperatureSensorHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<TemperatureSensorResponseDto>> Handle(TemperatureSensorEditCommand request, CancellationToken cancellationToken)
    {
        #region Validation
        var validation = new CreateTemperatureSensorValidator();
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
