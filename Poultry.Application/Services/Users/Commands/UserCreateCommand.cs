using MediatR;
using Poultry.Application.Core;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users.Commands;


public class UserCreateCommand : IRequest<ResultDto<AppUser>>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

