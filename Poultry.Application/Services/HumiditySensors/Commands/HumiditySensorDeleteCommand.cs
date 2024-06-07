using MediatR;
using Poultry.Application.Core;

namespace Poultry.Application.Services.HumiditySensors.Commands;

public class HumiditySensorDeleteCommand : IRequest<ResultDto<Unit>>
{
    public long Id { get; set; }
}


