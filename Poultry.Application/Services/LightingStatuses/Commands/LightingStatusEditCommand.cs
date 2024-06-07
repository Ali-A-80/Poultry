using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.LightingStatuses.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.LightingStatuses.Commands;


public class LightingStatusEditCommand : IRequest<ResultDto<LightingStatusResponseDto>>
{
    public long Id { get; set; }
    public LightingStatusType LightingStatusType { get; set; }
    public int Amount { get; set; }
}

