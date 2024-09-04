using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.LightingStatuses.Dtos;

namespace Poultry.Application.Services.LightingStatuses.Queries;


public class LightingStatusListQuery : IRequest<ResultDto<List<LightingStatusResponseDto>>>
{

}

