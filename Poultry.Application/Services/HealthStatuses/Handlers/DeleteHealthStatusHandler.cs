using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.HealthStatuses.Commands;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.HealthStatuses.Handlers;

public class DeleteHealthStatusHandler : IRequestHandler<HealthStatusDeleteCommand, ResultDto<Unit>>
{

    private readonly DatabaseContext _context;

    public DeleteHealthStatusHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<Unit>> Handle(HealthStatusDeleteCommand request, CancellationToken cancellationToken)
    {
        #region Validation
        var validation = new HealthStatusDeleteValidator();
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return ResultDto<Unit>.Failure(new List<string> { $"{validationResult.Errors[0].ErrorMessage}" });
        #endregion

        var healthStatus = await _context.HealthStatuses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (healthStatus is null)
            return ResultDto<Unit>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

        healthStatus.IsRemoved = true;
        healthStatus.RemoveTime = DateTime.Now;

        await _context.SaveChangesAsync(cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);
    }

}
