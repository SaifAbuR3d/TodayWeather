using Microsoft.AspNetCore.Mvc;
namespace AuthenticationService.Controllers;

[Route("api/authentication")]
[ApiController]
public  class AuthenticationController : ControllerBase
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationController(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("login")]
    public ActionResult<string> Authenticate(AutheticationRequestBody autheticationRequestBody)
    {
        var token = _jwtTokenGenerator.GenerateToken(autheticationRequestBody.UserName,
            autheticationRequestBody.Password); 

        if (token == null)
        {
            return Unauthorized(); 
        }

        return Ok(token);
    }
}
