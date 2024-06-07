using MediatR;
using Poultry.Application.Core;

namespace Poultry.Application.Services.LightingStatuses.Commands;


public class LightingStatusDeleteCommand : IRequest<ResultDto<Unit>>
{
    public long Id { get; set; }
}

