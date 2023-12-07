using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.Zones
{
    public class Edit
    {
        public class Command : IRequest<ResultDto<ZoneResponseDto>>
        {
            public Domain.Entities.Zone Zone { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResultDto<ZoneResponseDto>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<ZoneResponseDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                #region Validation
                var validation = new ZoneValidator();
                var validationResult = await validation.ValidateAsync(request.Zone, cancellationToken);

                if (!validationResult.IsValid)
                {
                    var errors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                    return ResultDto<ZoneResponseDto>.Failure(errors);
                }
                #endregion

                var zone = await _context.Zones.Include(x => x.LightingStatus)/*.Include(x => x.Weather)*/
                    .FirstOrDefaultAsync(x => x.Id == request.Zone.Id, cancellationToken);

                if (zone is null)
                    return ResultDto<ZoneResponseDto>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

                zone.ZoneType = request.Zone.ZoneType;
                zone.UpdateTime = DateTime.Now;

                _context.Zones.Update(zone);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<ZoneResponseDto>.Success(new ZoneResponseDto(zone));
            }
        }
    }
}
