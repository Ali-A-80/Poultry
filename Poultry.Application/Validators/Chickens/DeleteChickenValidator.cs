using FluentValidation;
using Poultry.Application.Services.Chickens.Commands;
using Poultry.Domain.Repositories.Chickens;

namespace Poultry.Application.Validators.Chickens;

public class DeleteChickenValidator : AbstractValidator<DeleteChickenCommand>
{
    private readonly IChickenCommandRepository _chickenCommandRepository;

    public DeleteChickenValidator(IChickenCommandRepository chickenCommandRepository)
    {
        _chickenCommandRepository = chickenCommandRepository;

        RuleFor(x => x.Id).MustAsync(Exists).WithMessage("مرغ با شناسه وارد شده وجود ندارد");
    }

    private async Task<bool> Exists(long id, CancellationToken cancellationToken)
    {
        return await _chickenCommandRepository.ChickenExists(id, cancellationToken);
    }
}


