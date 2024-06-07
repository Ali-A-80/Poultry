using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.HealthStatuses.Commands;
using Poultry.Application.Services.HealthStatuses.Dtos;
using Poultry.Application.Validators;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.HealthStatuses.Handlers;

public class EditHealthStatusHandler : IRequestHandler<HealthStatusEditCommand, ResultDto<HealthStatusResponseDto>>
{

    private readonly DatabaseContext _context;

    public EditHealthStatusHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<HealthStatusResponseDto>> Handle(HealthStatusEditCommand request, CancellationToken cancellationToken)
    {
        #region Validation
        var validation = new EditHealthStatusValidator();
        var validationResult = await validation.ValidateAsync(request.HealthStatus, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(error.ErrorMessage);
            }
            return ResultDto<HealthStatusResponseDto>.Failure(errors);
        }
        #endregion

        var healthStatus = await _context.HealthStatuses.FirstOrDefaultAsync(x => x.Id == request.HealthStatus.Id, cancellationToken);

        if (healthStatus is null)
            return ResultDto<HealthStatusResponseDto>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

        healthStatus.BodyTemprature = request.HealthStatus.BodyTemprature;
        healthStatus.CheckupDate = request.HealthStatus.CheckupDate;
        healthStatus.HealthLevel = request.HealthStatus.HealthLevel;
        healthStatus.UpdateTime = DateTime.Now;

        _context.HealthStatuses.Update(healthStatus);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultDto<HealthStatusResponseDto>.Success(new HealthStatusResponseDto(healthStatus));
    }

}
