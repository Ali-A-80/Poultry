using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.Zones
{
    public class Create
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

                var zone = new Domain.Entities.Zone()
                {
                    ZoneType = request.Zone.ZoneType
                };

                var rand = new Random();

                var lightingStatus = new LightingStatus
                {
                    Zone = zone,
                    Amount = rand.Next(0,100),
                    LightingStatusType = LightingStatusType.normal
                };

                await _context.Zones.AddAsync(zone , cancellationToken);
                await _context.LightingStatuses.AddAsync(lightingStatus , cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<ZoneResponseDto>.Success(new ZoneResponseDto(zone));


            }
        }
    }
}
