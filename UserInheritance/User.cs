namespace UserInheritance;

public class User : Profile
{
    public int Age { get; set; }

    public User(string name, string surname, int age, string email, string password, UserRole userrole) : base(name, surname, email, password, userrole)
    {
        Age = age;
    }
}