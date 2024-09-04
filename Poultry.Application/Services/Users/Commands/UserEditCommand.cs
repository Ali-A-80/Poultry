using MediatR;
using Poultry.Application.Core;
using Poultry.Domain.Entities;
using System.Security.Claims;

namespace Poultry.Application.Services.Users.Commands;

public class UserEditCommand : IRequest<ResultDto<AppUser>>
{
    public ClaimsPrincipal Principal { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
}

