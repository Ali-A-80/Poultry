using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.HumiditySensors
{
    public class Create
    {
        public class Command : IRequest<ResultDto<HumiditySensorResponseDto>>
        {
            public HumiditySensor HumiditySensor { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResultDto<HumiditySensorResponseDto>>
        {
            private readonly DatabaseContext _context;

            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ResultDto<HumiditySensorResponseDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                #region Validation
                var validation = new HumiditySensorValidator();
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

                var zone = await _context.Zones.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.HumiditySensor.ZoneId , cancellationToken);

                if (zone is null)               
                    return ResultDto<HumiditySensorResponseDto>.Failure(new List<string> { "ناحیه مورد نظر یافت نشد" });               

                var humiditySensor = new HumiditySensor()
                {
                    Amount = request.HumiditySensor.Amount,
                    HumidityStatus = request.HumiditySensor.HumidityStatus,
                    ZoneId = zone.Id
                };

                await _context.HumiditySensors.AddAsync(humiditySensor, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<HumiditySensorResponseDto>.Success(new HumiditySensorResponseDto(humiditySensor));
            }
        }
    }
}
