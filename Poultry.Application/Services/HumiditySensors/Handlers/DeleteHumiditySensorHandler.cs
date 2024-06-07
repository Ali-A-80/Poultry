using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.HumiditySensors.Commands;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.HumiditySensors.Handlers;

public class DeleteHumiditySensorHandler : IRequestHandler<HumiditySensorDeleteCommand, ResultDto<Unit>>
{

    private readonly DatabaseContext _context;

    public DeleteHumiditySensorHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<Unit>> Handle(HumiditySensorDeleteCommand request, CancellationToken cancellationToken)
    {
        #region Validation
        var validation = new HumiditySensorDeleteValidator();
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return ResultDto<Unit>.Failure(new List<string> { $"{validationResult.Errors[0].ErrorMessage}" });
        #endregion

        var humiditySensor = await _context.HumiditySensors.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (humiditySensor is null)
            return ResultDto<Unit>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

        humiditySensor.IsRemoved = true;
        humiditySensor.RemoveTime = DateTime.Now;

        await _context.SaveChangesAsync(cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);
    }

}
