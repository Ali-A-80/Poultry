using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.FoodServices.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.FoodServices.Commands;


public class FoodServiceCreateCommand : IRequest<ResultDto<FoodServiceResponseDto>>
{
    public FoodType FoodType { get; set; }
    public int Amount { get; set; }
}

