using TodayWeather.Models;

namespace TodayWeather.Services;

public static class AuthenticationService
{
    public static User? ValidateUserCredentials(string? userName, string? password)
    {
        if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)) return null;

        var user = User.Users.FirstOrDefault(e => e.UserName == userName && e.Password == password);
        return user;
    }
}