using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.EntityValidators;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users
{
    public class Create
    {
        public class Command : IRequest<ResultDto<AppUser>>
        {
            public UserRequestDto UserRequest { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResultDto<AppUser>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public Handler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }
            public async Task<ResultDto<AppUser>> Handle(Command request, CancellationToken cancellationToken)
            {
                #region Validation
                var validation = new UserValidator();
                var fluentResult = await validation.ValidateAsync(request.UserRequest , cancellationToken);
                if (!fluentResult.IsValid)
                {
                    List<string> fluentErrors = new();
                    foreach (var item in fluentResult.Errors)
                    {
                        fluentErrors.Add(item.ErrorMessage);
                    }
                    return ResultDto<AppUser>.Failure(fluentErrors);
                }
                #endregion

                #region UserCreation
                var user = new AppUser
                {
                    //Email = request.UserRequest.Email,
                    UserName = request.UserRequest.Username,
                };
                var result = await _userManager.CreateAsync(user, request.UserRequest.Password);
                #endregion

                #region RoleCreation
                //var ExistingRoles = await _roleManager.Roles.AsNoTracking().Select(r => r.Name).ToListAsync(cancellationToken);
                //var verifiedRoles = request.UserRequest.Roles.Where(p => !ExistingRoles.Contains(p)).ToList();
                //foreach (var item in verifiedRoles)
                //{
                //    await _roleManager.CreateAsync(new IdentityRole(item));
                //}
                #endregion

                if (result.Succeeded)
                {
                    return ResultDto<AppUser>.Success(user);
                }

                List<string> managerErrors = new();
                foreach (var item in result.Errors)
                {
                    managerErrors.Add(item.Description);
                }
                return ResultDto<AppUser>.Failure(managerErrors);
            }
        }
    }
}
