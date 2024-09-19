namespace UserInheritance;

public abstract class Abstract
{
    public abstract void ShowProfiles();
    public abstract bool SignIn(string email, string password);
    public abstract void SignUp(Profile profile);
}