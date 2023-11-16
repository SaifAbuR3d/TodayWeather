using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationService;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string? GenerateToken(string? userName, string? password)
    {
        var user = TodayWeather.Services.AuthenticationService.ValidateUserCredentials(
                               userName, password);

        if (user == null)
        {
            return null;
        }

        var securityKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(_configuration["JWTToken:Key"]));
        var signingCredentials = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
        claimsForToken.Add(new Claim("full_name", user.FullName.ToString()));
        claimsForToken.Add(new Claim("email_address", user.Email));
        claimsForToken.Add(new Claim("user_name", user.UserName));

        var jwtSecurityToken = new JwtSecurityToken(
            _configuration["JWTToken:Issuer"],
            _configuration["JWTToken:Audience"],
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);

        var tokenToReturn = new JwtSecurityTokenHandler()
           .WriteToken(jwtSecurityToken);

        return tokenToReturn;
    }

    public bool ValidateToken(string token)
    {
        throw new NotImplementedException();
    }

}