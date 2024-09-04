using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users.Commands;

public class UserLoginCommand : IRequest<ResultDto<AppUser>>
{
    public UserCreateLoginRequestDto UserRequest { get; set; }
}

