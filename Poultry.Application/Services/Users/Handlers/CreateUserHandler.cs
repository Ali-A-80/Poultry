using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Commands;
using Poultry.Domain.Entities;
using Poultry.Domain.Repositories.Users;

namespace Poultry.Application.Services.Users.Handlers;

public class CreateUserHandler : IRequestHandler<UserCreateCommand, ResultDto<AppUser>>
{
    private readonly IUserCommandRepository _userCommandRepository;

    public CreateUserHandler(IUserCommandRepository userCommandRepository)
    {
        _userCommandRepository = userCommandRepository;
    }

    public async Task<ResultDto<AppUser>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var user = new AppUser
        {
            UserName = request.Username,
        };

        var result = await _userCommandRepository.AddUser(user, request.Password);

        if (!result.Succeeded)
        {
            List<string> managerErrors = new();
            foreach (var item in result.Errors)
            {
                managerErrors.Add(item.Description);
            }
            return ResultDto<AppUser>.Failure(managerErrors);
        }

        return ResultDto<AppUser>.Success(user);
    }

}
