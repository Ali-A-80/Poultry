using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Commands;
using Poultry.Domain.Repositories.Users;

namespace Poultry.Application.Services.Users.Handlers;

public class IsSignedInUserHandler : IRequestHandler<UserIsSignedInCommand, ResultDto<bool>>
{
    private readonly IUserQueryRepository _userQueryRepository;

    public IsSignedInUserHandler(IUserQueryRepository userQueryRepository)
    {
        _userQueryRepository = userQueryRepository;
    }

    public async Task<ResultDto<bool>> Handle(UserIsSignedInCommand request, CancellationToken cancellationToken)
    {
        var result = await _userQueryRepository.GetByName(request.Principal.Identity!.Name!);

        var response = result != null;

        return ResultDto<bool>.Success(response);
    }

}
