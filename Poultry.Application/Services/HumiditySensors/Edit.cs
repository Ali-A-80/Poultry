using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Validators;
using Poultry.Domain.Entities;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.HumiditySensors
{
    public class Edit
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

                var humiditySensor = await _context.HumiditySensors.FirstOrDefaultAsync(x => x.Id == request.HumiditySensor.Id, cancellationToken);

                if (humiditySensor is null)
                    return ResultDto<HumiditySensorResponseDto>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

                humiditySensor.Amount = humiditySensor.Amount;
                humiditySensor.HumidityStatus = humiditySensor.HumidityStatus;
                humiditySensor.UpdateTime = DateTime.Now;

                _context.HumiditySensors.Update(humiditySensor);
                await _context.SaveChangesAsync(cancellationToken);

                return ResultDto<HumiditySensorResponseDto>.Success(new HumiditySensorResponseDto(humiditySensor));
            }
        }
    }
}
