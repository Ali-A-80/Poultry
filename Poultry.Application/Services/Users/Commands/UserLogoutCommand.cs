using MediatR;
using Poultry.Application.Core;

namespace Poultry.Application.Services.Users.Commands;


public class UserLogoutCommand : IRequest<ResultDto<Unit>>
{

}

