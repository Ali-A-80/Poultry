using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.TemperatureSensors.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.TemperatureSensors.Commands;


public class TemperatureSensorCreateCommand : IRequest<ResultDto<TemperatureSensorResponseDto>>
{
    public TemperatureStatus TemperatureStatus { get; set; }
    public int Amount { get; set; }

    public long ZoneId { get; set; }
}

