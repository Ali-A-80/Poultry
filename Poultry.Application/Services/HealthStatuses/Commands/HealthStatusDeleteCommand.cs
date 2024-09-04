using MediatR;
using Poultry.Application.Core;

namespace Poultry.Application.Services.HealthStatuses.Commands;


public class HealthStatusDeleteCommand : IRequest<ResultDto<Unit>>
{
    public long Id { get; set; }
}

