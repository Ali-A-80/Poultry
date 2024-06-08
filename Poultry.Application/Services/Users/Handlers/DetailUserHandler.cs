using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Commands;
using Poultry.Application.Services.Users.Dtos;
using Poultry.Persistance.Repositories.Users;

namespace Poultry.Application.Services.Users.Handlers;

public class DetailUserHandler : IRequestHandler<UserDetailCommand, ResultDto<UserInfoResponseDto>>
{
    private readonly IUserQueryRepository _userQueryRepository;

    public DetailUserHandler(IUserQueryRepository userQueryRepository)
    {
        _userQueryRepository = userQueryRepository;
    }

    public async Task<ResultDto<UserInfoResponseDto>> Handle(UserDetailCommand request, CancellationToken cancellationToken)
    {
        var result = await _userQueryRepository.GetByName(request.Principal.Identity!.Name!);

        return ResultDto<UserInfoResponseDto>.Success(new UserInfoResponseDto
        {
            Email = result.Email!,
            PhoneNumber = result.PhoneNumber!,
            Username = result.UserName!
        });
    }

}
