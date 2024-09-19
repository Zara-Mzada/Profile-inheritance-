using System.Collections;

namespace UserInheritance;

public class AdminController : Abstract
{
    public ArrayList Admins { get; set; }

    public AdminController()
    {
        Admins = new ArrayList();
    }

    public void AddAdmin(Admin admin)
    {
        Admins.Add(admin);
    }
    
    // show Admins
    public override void ShowProfiles()
    {
        int id = 1;
        foreach (Admin admin in Admins)
        {
            Console.WriteLine($"PROFILE {id}\n" +
                              $"Name: {admin.Name}\n" +
                              $"Surname: {admin.Surname}\n" +
                              $"Age: {admin.Age}\n" +
                              $"Email: {admin.Email}\n" +
                              $"Password: {admin.Password}\n" +
                              $"Role: {UserRole.Admin}\n" +
                              $"=============================\n" +
                              $"=============================");
            id++;
        }
    }
    
    // Sign Up
    public override void SignUp(Profile profile)
    {
        Admins.Add(profile);
    }
    
    // Sign in
    public override bool SignIn(string email, string password)
    {
        foreach (Admin admin in Admins)
        {
            if (admin.Email == email && admin.Password == password)
            {
                return true;
            }
        }

        return false;
    }
}

