using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Poultry.Application.Core;
using Poultry.Application.Services.Users.Commands;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Poultry.Application.Services.Users.Handlers;

public class ValidateTokenServiceUserHandler : IRequestHandler<UserValidateTokenServiceCommand, ResultDto<ClaimsPrincipal>>
{

    private readonly IConfiguration _config;

    public ValidateTokenServiceUserHandler(IConfiguration config)
    {
        _config = config;
    }

    public async Task<ResultDto<ClaimsPrincipal>> Handle(UserValidateTokenServiceCommand request, CancellationToken cancellationToken)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Key"])),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tok = request.Token;
        var temp = "Bearer ";
        if (tok is not null)
        {
            if (request.Token.StartsWith(temp))
                tok = tok.Substring(temp.Length);
        }

        try
        {
            var principal = tokenHandler.ValidateToken(tok, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals("HS512"))
                return ResultDto<ClaimsPrincipal>.Failure(new List<string> { "Invalid token" });
            return ResultDto<ClaimsPrincipal>.Success(principal);
        }
        catch
        {
            return ResultDto<ClaimsPrincipal>.Failure(new List<string> { "Invalid token" });
        }

    }

}
