using MediatR;
using Poultry.Application.Core;

namespace Poultry.Application.Services.Chickens.Commands;

public class DeleteChickenCommand : IRequest<ResultDto<Unit>>
{
    public long Id { get; set; }
}

