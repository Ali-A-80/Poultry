using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Commands;
using Poultry.Domain.Entities;
using Poultry.Persistance.Repositories.Users;

namespace Poultry.Application.Services.Users.Handlers;

public partial class EditUserHandler : IRequestHandler<UserEditCommand, ResultDto<AppUser>>
{

    private readonly IUserCommandRepository _userCommandRepository;

    public EditUserHandler(IUserCommandRepository userCommandRepository)
    {
        _userCommandRepository = userCommandRepository;
    }
    public async Task<ResultDto<AppUser>> Handle(UserEditCommand request, CancellationToken cancellationToken)
    {
        var user = await _userCommandRepository.GetByName(request.Principal.Identity!.Name!);

        user.UserName = request.UserName;
        user.Email = request.Email;
        user.PhoneNumber = request.PhoneNumber;
        
        var response = await _userCommandRepository.UpdateUser(user);

        if (!response.Succeeded)
        {
            List<string> managerErrors = new();
            foreach (var item in response.Errors)
            {
                managerErrors.Add(item.Description);
            }
            return ResultDto<AppUser>.Failure(managerErrors);
        }

        return ResultDto<AppUser>.Success(user);
    }

}
