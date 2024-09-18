namespace UserInheritance;

public class Admin : Profile
{
    public int Age { get; set; }
    
    public Admin(string name, string surname, int age, string email, string password, UserRole userrole) : base(name, surname, email, password, userrole)
    {
        Age = age;
    }
}