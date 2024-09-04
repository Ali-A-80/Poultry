using MediatR;
using Poultry.Application.Core;

namespace Poultry.Application.Services.TemperatureSensors.Commands;


public class TemperatureSensorDeleteCommand : IRequest<ResultDto<Unit>>
{
    public long Id { get; set; }
}

