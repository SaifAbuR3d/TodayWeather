namespace TodayWeather.Models;

public class User
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; private set; } = string.Empty;
    public string Password { get; private set; }

    public static readonly List<User> Users = new List<User>
        {
          new User("joe doe", "sample@email.com","saif", "123"),
          new User("kyle din", "sample1@domain.com","saif1", "132"),
          new User("bros lee", "test@email.com","saif2", "321"),
          new User("kevin spacy", "sales@gmail.com","saif3", "321"),
        };
    public User(string fullName, string email, string userName, string password)
    {
        FullName = fullName;
        Email = email;
        UserName = userName;
        Password = password;
    }

}
