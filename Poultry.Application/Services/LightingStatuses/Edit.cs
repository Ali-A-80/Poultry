using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.LightingStatuses
{
    public class Edit
    {
        public class Command : IRequest<ResultDto<LightingStatusResponseDto>>
        {
            public LightingStatus LightingStatus { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResultDto<LightingStatusResponseDto>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<LightingStatusResponseDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                #region Validation
                var validation = new LightingStatusValidator();
                var validationResult = await validation.ValidateAsync(request.LightingStatus, cancellationToken);

                if (!validationResult.IsValid)
                {
                    var errors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                    return ResultDto<LightingStatusResponseDto>.Failure(errors);
                }
                #endregion

                var lightingStatus = await _context.LightingStatuses.FirstOrDefaultAsync(x => x.Id == request.LightingStatus.Id, cancellationToken);

                if (lightingStatus is null)
                    return ResultDto<LightingStatusResponseDto>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

                lightingStatus.Amount = lightingStatus.Amount;
                lightingStatus.LightingStatusType = lightingStatus.LightingStatusType;
                lightingStatus.UpdateTime = DateTime.Now;

                _context.LightingStatuses.Update(lightingStatus);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<LightingStatusResponseDto>.Success(new LightingStatusResponseDto(lightingStatus));
            }
        }
    }
}
