using MediatR;
using Poultry.Application.Core;

namespace Poultry.Application.Services.Zones.Commands;


public class ZoneDeleteCommand : IRequest<ResultDto<Unit>>
{
    public long Id { get; set; }
}

