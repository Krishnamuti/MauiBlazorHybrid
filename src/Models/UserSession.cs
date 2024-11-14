namespace MauiHybridAuthentication.Models;

public class UserSession
{
    public string UserName { get; set; }
    public string Role { get; set; }

    public UserSession(string userName, string role)
    {
        UserName = userName;
        Role = role;
    }
}
