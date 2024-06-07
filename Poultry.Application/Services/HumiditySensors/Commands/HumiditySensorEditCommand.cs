using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.HumiditySensors.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.HumiditySensors.Commands;

public class HumiditySensorEditCommand : IRequest<ResultDto<HumiditySensorResponseDto>>
{
    public long Id { get; set; }
    public HumidityStatus HumidityStatus { get; set; }
    public int Amount { get; set; }

}

