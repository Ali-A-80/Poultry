using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Zones.Commands;
using Poultry.Application.Services.Zones.Dtos;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.Zones.Handlers;

public class Create
{

    public class Handler : IRequestHandler<ZoneCreateCommand, ResultDto<ZoneResponseDto>>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<ZoneResponseDto>> Handle(ZoneCreateCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validation = new CreateZoneValidator();
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

            var zone = new Zone()
            {
                ZoneType = request.Zone.ZoneType
            };

            var rand = new Random();

            var lightingStatus = new LightingStatus
            {
                Zone = zone,
                Amount = rand.Next(0, 100),
                LightingStatusType = LightingStatusType.normal
            };

            await _context.Zones.AddAsync(zone, cancellationToken);
            await _context.LightingStatuses.AddAsync(lightingStatus, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultDto<ZoneResponseDto>.Success(new ZoneResponseDto(zone));


        }
    }
}
