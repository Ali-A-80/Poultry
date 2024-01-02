using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Poultry.Application.Core;
using Poultry.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Poultry.Application.Services.Users
{
    public class TokenService
    {

        public class Command : IRequest<ResultDto<UserResponseDto>>
        {
            public AppUser AppUser { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResultDto<UserResponseDto>>
        {
            private readonly IConfiguration _config;
            public Handler(IConfiguration config)
            {
                _config = config;
            }
            public async Task<ResultDto<UserResponseDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var claims = new List<Claim>
                {
                    new (ClaimTypes.Name, request.AppUser.UserName),
                    new (ClaimTypes.NameIdentifier, request.AppUser.Id),
                };


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
                    SigningCredentials = creds,
                    Expires = DateTime.UtcNow.AddDays(7)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return ResultDto<UserResponseDto>.Success(new UserResponseDto
                {
                    Token = tokenHandler.WriteToken(token),
                    UserName = request.AppUser.UserName
                });
            }

        }
    }
}
