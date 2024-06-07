using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Chickens.Dtos;

namespace Poultry.Application.Services.Chickens.Queries;

public class ChickenListQuery : IRequest<ResultDto<List<ChickenResponseDto>>>
{

}

