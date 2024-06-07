using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.TemperatureSensors.Commands;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.TemperatureSensors.Handlers;

public class DeleteTemperatureSensorHandler : IRequestHandler<TemperatureSensorDeleteCommand, ResultDto<Unit>>
{
    private readonly DatabaseContext _context;

    public DeleteTemperatureSensorHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<Unit>> Handle(TemperatureSensorDeleteCommand request, CancellationToken cancellationToken)
    {
        #region Validation
        var validation = new TemperatureSensorDeleteValidator();
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return ResultDto<Unit>.Failure(new List<string> { $"{validationResult.Errors[0].ErrorMessage}" });
        #endregion

        var temperatureSensor = await _context.TemperatureSensors.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (temperatureSensor is null)
            return ResultDto<Unit>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

        temperatureSensor.IsRemoved = true;
        temperatureSensor.RemoveTime = DateTime.Now;

        await _context.SaveChangesAsync(cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);
    }

}
