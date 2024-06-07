using MediatR;
using Poultry.Application.Core;

namespace Poultry.Application.Services.VentilationSensors.Commands;


public class VentilationSensorDeleteCommand : IRequest<ResultDto<Unit>>
{
    public long Id { get; set; }
}

