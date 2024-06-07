using MediatR;
using Microsoft.AspNetCore.Identity;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Commands;
using Poultry.Application.Services.Users.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users.Handlers;

public class DetailUserHandler : IRequestHandler<UserDetailCommand, ResultDto<UserInfoResponseDto>>
{

    private readonly UserManager<AppUser> _userManager;

    public DetailUserHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<ResultDto<UserInfoResponseDto>> Handle(UserDetailCommand request, CancellationToken cancellationToken)
    {
        var result = await _userManager.FindByNameAsync(request.Principal.Identity.Name);

        if (result is null)
            return ResultDto<UserInfoResponseDto>.Failure(new List<string> { "کاربر یافت نشد" });

        return ResultDto<UserInfoResponseDto>.Success(new UserInfoResponseDto
        {
            Email = result.Email,
            PhoneNumber = result.PhoneNumber,
            Username = result.UserName
        });
    }

}
