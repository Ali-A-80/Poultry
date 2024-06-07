using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.LightingStatuses.Commands;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.LightingStatuses.Handlers;

public class DeleteLightingStatusHandler : IRequestHandler<LightingStatusDeleteCommand, ResultDto<Unit>>
{

    private readonly DatabaseContext _context;

    public DeleteLightingStatusHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<Unit>> Handle(LightingStatusDeleteCommand request, CancellationToken cancellationToken)
    {
        #region Validation
        var validation = new LightingStatusDeleteValidator();
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return ResultDto<Unit>.Failure(new List<string> { $"{validationResult.Errors[0].ErrorMessage}" });
        #endregion

        var lightingStatus = await _context.HumiditySensors.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (lightingStatus is null)
            return ResultDto<Unit>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

        lightingStatus.IsRemoved = true;
        lightingStatus.RemoveTime = DateTime.Now;

        await _context.SaveChangesAsync(cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);
    }

}
