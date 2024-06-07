using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.TemperatureSensors.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.TemperatureSensors.Commands;


public class TemperatureSensorEditCommand : IRequest<ResultDto<TemperatureSensorResponseDto>>
{
    public long Id { get; set; }
    public TemperatureStatus TemperatureStatus { get; set; }
    public int Amount { get; set; }
}

