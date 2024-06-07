using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.HealthStatuses.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.HealthStatuses.Commands;


public class HealthStatusEditCommand : IRequest<ResultDto<HealthStatusResponseDto>>
{
    public long Id { get; set; }
    public int BodyTemprature { get; set; }
    public HealthLevel HealthLevel { get; set; }
    public DateTime CheckupDate { get; set; }
}

