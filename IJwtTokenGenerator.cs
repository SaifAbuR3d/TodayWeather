namespace AuthenticationService
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(string? userName, string? password);
        public bool ValidateToken(string token);

    }
}