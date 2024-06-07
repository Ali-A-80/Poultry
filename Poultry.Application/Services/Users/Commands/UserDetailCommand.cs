using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Dtos;
using System.Security.Claims;

namespace Poultry.Application.Services.Users.Commands;


public class UserDetailCommand : IRequest<ResultDto<UserInfoResponseDto>>
{
    public ClaimsPrincipal Principal { get; set; }
}

