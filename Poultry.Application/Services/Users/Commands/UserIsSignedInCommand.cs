using MediatR;
using Poultry.Application.Core;
using System.Security.Claims;

namespace Poultry.Application.Services.Users.Commands;

public class UserIsSignedInCommand : IRequest<ResultDto<bool>>
{
    public ClaimsPrincipal Principal { get; set; }
}

