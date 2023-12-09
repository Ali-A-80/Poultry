using MediatR;
using Microsoft.AspNetCore.Identity;
using Poultry.Application.Core;
using Poultry.Domain.Entities;
using System.Security.Claims;

namespace Poultry.Application.Services.Users
{
    public class Detail
    {
        public class Command : IRequest<ResultDto<UserInfoResponseDro>>
        {
            public ClaimsPrincipal Principal { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResultDto<UserInfoResponseDro>>
        {
            private readonly UserManager<AppUser> _userManager;

            public Handler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }
            public async Task<ResultDto<UserInfoResponseDro>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _userManager.FindByNameAsync(request.Principal.Identity.Name);

                if (result is null)
                    return ResultDto<UserInfoResponseDro>.Failure(new List<string> { "کاربر یافت نشد" });

                return ResultDto<UserInfoResponseDro>.Success(new UserInfoResponseDro
                {
                    Email = result.Email,
                    MobileNumber = result.Email,
                    Username = result.UserName
                });
            }
        }
    }
}
