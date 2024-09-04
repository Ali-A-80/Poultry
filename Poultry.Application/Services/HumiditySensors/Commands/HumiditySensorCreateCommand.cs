using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.HumiditySensors.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.HumiditySensors.Commands;


public class HumiditySensorCreateCommand : IRequest<ResultDto<HumiditySensorResponseDto>>
{
    public HumidityStatus HumidityStatus { get; set; }
    public int Amount { get; set; }
    public long ZoneId { get; set; }
}

