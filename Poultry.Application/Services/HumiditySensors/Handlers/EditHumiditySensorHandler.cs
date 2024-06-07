using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.HumiditySensors.Commands;
using Poultry.Application.Services.HumiditySensors.Dtos;
using Poultry.Application.Validators;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.HumiditySensors.Handlers;

public class EditHumiditySensorHandler : IRequestHandler<HumiditySensorEditCommand, ResultDto<HumiditySensorResponseDto>>
{

    private readonly DatabaseContext _context;

    public EditHumiditySensorHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<HumiditySensorResponseDto>> Handle(HumiditySensorEditCommand request, CancellationToken cancellationToken)
    {
        #region Validation
        var validation = new EditHumiditySensorValidator();
        var validationResult = await validation.ValidateAsync(request.HumiditySensor, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(error.ErrorMessage);
            }
            return ResultDto<HumiditySensorResponseDto>.Failure(errors);
        }
        #endregion

        var humiditySensor = await _context.HumiditySensors.FirstOrDefaultAsync(x => x.Id == request.HumiditySensor.Id, cancellationToken);

        if (humiditySensor is null)
            return ResultDto<HumiditySensorResponseDto>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

        humiditySensor.Amount = humiditySensor.Amount;
        humiditySensor.HumidityStatus = humiditySensor.HumidityStatus;
        humiditySensor.UpdateTime = DateTime.Now;

        _context.HumiditySensors.Update(humiditySensor);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultDto<HumiditySensorResponseDto>.Success(new HumiditySensorResponseDto(humiditySensor));
    }

}
