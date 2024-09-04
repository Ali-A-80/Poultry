using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Zones.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Zones.Commands;


public class ZoneEditCommand : IRequest<ResultDto<ZoneResponseDto>>
{
    public long Id { get; set; }
    public ZoneType ZoneType { get; set; }
}

