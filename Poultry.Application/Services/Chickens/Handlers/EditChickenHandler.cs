using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Chickens.Commands;
using Poultry.Application.Services.Chickens.Dtos;
using Poultry.Domain.Repositories.Chickens;

namespace Poultry.Application.Services.Chickens.Handlers;

public class EditChickenHandler : IRequestHandler<EditChickenCommand, ResultDto<ChickenResponseDto>>
{

    private readonly IChickenCommandRepository _chickenCommandRepository;

    public EditChickenHandler(IChickenCommandRepository chickenCommandRepository)
    {
        _chickenCommandRepository = chickenCommandRepository;
    }

    public async Task<ResultDto<ChickenResponseDto>> Handle(EditChickenCommand request, CancellationToken cancellationToken)
    {

        var chicken = await _chickenCommandRepository.GetChickenById(request.Id, cancellationToken);

        chicken.Age = request.Age;
        chicken.ChickenType = request.ChickenType;
        chicken.Gender = request.Gender;
        chicken.LayingRate = request.LayingRate;
        chicken.Weight = request.Weight;
        chicken.UpdateTime = DateTime.Now;

        await _chickenCommandRepository.UpdateChicken(chicken, cancellationToken);

        return ResultDto<ChickenResponseDto>.Success(new ChickenResponseDto(chicken));
    }

}

