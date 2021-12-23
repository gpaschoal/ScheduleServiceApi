using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ScheduleService.Application.Handler.Services.Models;
using ScheduleService.Application.Handler.Services.Responses;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Shared.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ScheduleService.Application.Handler.Services;

public class TokenService : ITokenService
{
    private readonly JWTEncriptionModel _jwtEncriptionModel;

    public TokenService(IOptions<JWTEncriptionModel> jwtEncriptionModel)
    {
        _jwtEncriptionModel = jwtEncriptionModel.Value;
    }

    public TokenResponse TokenGenerator(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtEncriptionModel.Key);
        var expirationDate = DateTime.UtcNow.AddHours(_jwtEncriptionModel.HoursToExpire);
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(IdentityConstants.UserIdentifier, user.Id.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expirationDate,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };

        var securyToken = tokenHandler.CreateToken(tokenDescriptor);

        var response = new TokenResponse
        {
            Token = tokenHandler.WriteToken(securyToken),
            ExpirationDate = expirationDate
        };

        return response;
    }
}
