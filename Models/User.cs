namespace TodayWeather.Models;

public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; private set; } = string.Empty;
    public string Password { get; private set; }

    public static readonly List<User> Users = new List<User>
        {
          new User(1, "joe doe", "sample@email.com","saif", "123"),
          new User(2, "kyle din", "sample1@domain.com","saif1", "132"),
          new User(3, "bros lee", "test@email.com","saif2", "321"),
          new User(4, "kevin spacy", "sales@gmail.com","saif3", "321"),
        };
    public User(int userId, string fullName, string email, string userName, string password)
    {
        UserId = userId;
        FullName = fullName;
        Email = email;
        UserName = userName;
        Password = password;
    }

}
