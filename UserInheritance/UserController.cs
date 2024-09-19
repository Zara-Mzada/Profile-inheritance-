using System.Collections;

namespace UserInheritance;

public class UserController : Abstract
{
    public ArrayList Users { get; set; }

    public UserController()
    {
        Users = new ArrayList();
    }
    
    // Add user
    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public override void ShowProfiles()
    {
        int id = 1;
        foreach (User user in Users)
        {
            Console.WriteLine($"PROFILE {id}\n" +
                              $"Name: {user.Name}\n" +
                              $"Surname: {user.Surname}\n" +
                              $"Age: {user.Age}\n" +
                              $"Email: {user.Email}\n" +
                              $"Password: {user.Password}\n" +
                              $"Role: {UserRole.User}\n" +
                              $"=============================\n" +
                              $"=============================");
            id++;
        }
    }

    public override bool SignIn(string email, string password)
    {
        foreach (User user in Users)
        {
            if (user.Email == email && user.Password == password)
            {
                return true;
            }
        }

        return false;
    }

    // Sign Up
    public override void SignUp(Profile profile)
    {
        Users.Add(profile);
    }
}