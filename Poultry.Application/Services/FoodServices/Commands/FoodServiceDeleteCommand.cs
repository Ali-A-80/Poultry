using MediatR;
using Poultry.Application.Core;

namespace Poultry.Application.Services.FoodServices.Commands;


public class FoodServiceDeleteCommand : IRequest<ResultDto<Unit>>
{
    public long Id { get; set; }
}

