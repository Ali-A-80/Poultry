using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.HealthStatuses.Dtos;

namespace Poultry.Application.Services.HealthStatuses.Queries;


public class HealthStatusListQuery : IRequest<ResultDto<List<HealthStatusResponseDto>>>
{

}

