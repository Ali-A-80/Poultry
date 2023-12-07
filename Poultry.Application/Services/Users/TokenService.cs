using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Poultry.Application.Core;
using Poultry.Domain.Entities;
using System.Data;
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
            //public List<string>? Roles { get; set; }
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
                    //new (ClaimTypes.Email, request.AppUser.Email),
                };

                //if (request.Roles != null)
                //    claims.AddRange(request.Roles.Select(x => new Claim(ClaimTypes.Role, x)));

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

            #region KeyGen

            //public string GetKey()
            //{
            //    byte[] keyBytes = new byte[64];

            //    // Use RNGCryptoServiceProvider to generate a random key
            //    using (var rngCsp = new RNGCryptoServiceProvider())
            //    {
            //        rngCsp.GetBytes(keyBytes);
            //    }

            //    // Convert the byte array to a hex string (optional)
            //    return BitConverter.ToString(keyBytes).Replace("-", string.Empty);
            //}
            #endregion
        }
    }
}
