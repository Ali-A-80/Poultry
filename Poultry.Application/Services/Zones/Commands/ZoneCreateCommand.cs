using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Zones.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Zones.Commands;


public class ZoneCreateCommand : IRequest<ResultDto<ZoneResponseDto>>
{
    public ZoneType ZoneType { get; set; }
}

