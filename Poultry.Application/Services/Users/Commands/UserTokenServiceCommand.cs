using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Dtos;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users.Commands;

public class UserTokenServiceCommand : IRequest<ResultDto<UserResponseDto>>
{
    public AppUser AppUser { get; set; }
}

