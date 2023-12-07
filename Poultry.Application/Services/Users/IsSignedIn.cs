using MediatR;
using Microsoft.AspNetCore.Identity;
using Poultry.Application.Core;
using Poultry.Domain.Entities;
using System.Security.Claims;

namespace Poultry.Application.Services.Users
{
    public class IsSignedIn
    {
        public class Command : IRequest<ResultDto<bool>>
        {
            public ClaimsPrincipal Principal { get; set; }
        }
        public class Handler : IRequestHandler<Command, ResultDto<bool>>
        {
            private readonly UserManager<AppUser> _userManager;

            public Handler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }
            public async Task<ResultDto<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _userManager.FindByNameAsync(request.Principal.Identity.Name);
                if (result is not null)               
                    return ResultDto<bool>.Success(true);
                return ResultDto<bool>.Success(false);
            }
        }
    }
}
