using MediatR;
using Microsoft.AspNetCore.Identity;
using Poultry.Application.Core;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users
{
    public class Login
    {
        public class Command : IRequest<ResultDto<AppUser>>
        {
            public UserRequestDto UserRequest { get; set; }
        }
        public class Handler : IRequestHandler<Command, ResultDto<AppUser>>
        {
            private readonly SignInManager<AppUser> _signInManager;
            private readonly UserManager<AppUser> _userManager;

            public Handler(SignInManager<AppUser> signInManager , UserManager<AppUser> userManager)
            {
                _signInManager = signInManager;
                _userManager = userManager;
            }
            public async Task<ResultDto<AppUser>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(request.UserRequest.Username, request.UserRequest.Password, false, false);
                
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(request.UserRequest.Username);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return ResultDto<AppUser>.Success(user);
                }
                return ResultDto<AppUser>.Failure(new List<string> { "ورود ناموفق"});

            }
        }
    }

}
