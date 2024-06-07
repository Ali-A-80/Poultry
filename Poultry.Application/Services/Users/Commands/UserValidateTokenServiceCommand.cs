using MediatR;
using Poultry.Application.Core;
using System.Security.Claims;

namespace Poultry.Application.Services.Users.Commands;

public class UserValidateTokenServiceCommand : IRequest<ResultDto<ClaimsPrincipal>>
{
    public string Token { get; set; }
}

