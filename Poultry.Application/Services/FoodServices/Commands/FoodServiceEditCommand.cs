using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.FoodServices.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.FoodServices.Commands;


public class FoodServiceEditCommand : IRequest<ResultDto<FoodServiceResponseDto>>
{
    public long Id { get; set; }
    public FoodType FoodType { get; set; }
    public int Amount { get; set; }
}


