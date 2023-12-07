using MediatR;
using Microsoft.AspNetCore.Identity;
using Poultry.Application.Core;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users
{
    public class Logout
    {
        public class Command : IRequest<ResultDto<Unit>>
        {

        }
        public class Handler : IRequestHandler<Command, ResultDto<Unit>>
        {
            private readonly SignInManager<AppUser> _signInManager;

            public Handler(SignInManager<AppUser> signInManager)
            {
                _signInManager = signInManager;
            }
            public async Task<ResultDto<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                await _signInManager.SignOutAsync();
                return ResultDto<Unit>.Success(Unit.Value);
            }
        }
    }
}
