using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Chickens.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Chickens.Commands;

public class EditChickenCommand : IRequest<ResultDto<ChickenResponseDto>>
{
    public long Id { get; set; }
    public bool Gender { get; set; }
    public byte Age { get; set; }
    public ChickenType ChickenType { get; set; }
    public int Weight { get; set; }
    public byte LayingRate { get; set; }
}

