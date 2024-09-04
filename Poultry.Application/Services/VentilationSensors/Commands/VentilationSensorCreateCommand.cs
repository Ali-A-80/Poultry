using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.VentilationSensors.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.VentilationSensors.Commands;


public class VentilationSensorCreateCommand : IRequest<ResultDto<VentilationSensorResponseDto>>
{
    public VentilationStatus VentilationStatus { get; set; }
    public float AirFlow { get; set; }

    public long ZoneId { get; set; }
}

