using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Chickens.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Chickens.Commands;

public class CreateChickenCommand : IRequest<ResultDto<ChickenResponseDto>>
{
    public bool Gender { get; set; }
    public byte Age { get; set; }
    public ChickenType ChickenType { get; set; }
    public int Weight { get; set; }
    public byte LayingRate { get; set; }
}

