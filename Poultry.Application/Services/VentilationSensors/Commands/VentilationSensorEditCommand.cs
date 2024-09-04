using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.VentilationSensors.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.VentilationSensors.Commands;


public class VentilationSensorEditCommand : IRequest<ResultDto<VentilationSensorResponseDto>>
{
    public long Id { get; set; }
    public VentilationStatus VentilationStatus { get; set; }
    public float AirFlow { get; set; }
}

