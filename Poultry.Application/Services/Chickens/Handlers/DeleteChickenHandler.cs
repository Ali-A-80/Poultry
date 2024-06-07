using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Chickens.Commands;
using Poultry.Persistance.Repositories.Chickens;

namespace Poultry.Application.Services.Chickens.Handlers;

public class DeleteChickenHandler : IRequestHandler<DeleteChickenCommand, ResultDto<Unit>>
{

    private readonly IChickenCommandRepository _chickenCommandRepository;

    public DeleteChickenHandler(IChickenCommandRepository chickenCommandRepository)
    {
        _chickenCommandRepository = chickenCommandRepository;
    }
    public async Task<ResultDto<Unit>> Handle(DeleteChickenCommand request, CancellationToken cancellationToken)
    {
        var chicken = await _chickenCommandRepository.GetChickenById(request.Id, cancellationToken);

        chicken.IsRemoved = true;
        chicken.RemoveTime = DateTime.Now;

        await _chickenCommandRepository.UpdateChicken(chicken, cancellationToken);

        return ResultDto<Unit>.Success(Unit.Value);
    }

}

