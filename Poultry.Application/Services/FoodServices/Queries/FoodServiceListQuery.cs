using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.FoodServices.Dtos;

namespace Poultry.Application.Services.FoodServices.Queries;


public class FoodServiceListQuery : IRequest<ResultDto<List<FoodServiceResponseDto>>>
{

}

