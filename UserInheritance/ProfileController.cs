using System.Collections;

namespace UserInheritance;

// ================================================================================================
// PROFILE CONTROLLER ISLETMEMISEM, SADECE O DEFEDEN QALIB VE FUNCTIONLARI RAHAT YAZMAQCUN SILMEDIM
// ================================================================================================

public class ProfileController
{
    public ArrayList Profiles { get; set; }

    public ProfileController()
    {
        Profiles = new ArrayList();
    }
    
    // Add profile by contructor
    public void AddProfile(Profile profile)
    {
        Profiles.Add(profile);
    }
    
    // Show profiles
    public void ShowAllProfiles()
    {
        int id = 1;
        foreach (Profile profile in Profiles)
        {
            if (profile is Admin admin)
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
            }
            else if(profile is User user)
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
            }
            id++;
        }
    }
    
    // Sign Up
    public void SignUp(Profile profile)
    {
        Profiles.Add(profile);
    }
    
    // Sign In
    public bool SignIn(string email, string password)
    {
        foreach (Profile profile in Profiles)
        {
            if (profile.Email == email && profile.Password == password)
            {
                return true;
            }
        }
        return false;
    }
    
    // Check role
    public bool CheckingRole(string email, string password)
    {
        foreach (Profile profile in Profiles)
        {
            if (profile.Email == email && profile.Password == password && profile.UserRole == UserRole.Admin)
            {
                return true;
            }
        }
        return false;
    }
}