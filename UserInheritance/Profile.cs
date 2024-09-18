namespace UserInheritance;

public class Profile
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }

    public Profile(string name, string surname, string email, string password, UserRole userrole)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Password = password;
        UserRole = userrole;
    }
}