using System;
using UserInheritance;

public class Program
{
    public static void Main(string[] args)
    {
        UserController userController = new UserController();
        AdminController adminController = new AdminController();

        Admin admin1 = new Admin("Zahra", "Malikzada", 12, "zahra@gmail.com", "1234", UserRole.Admin);
        User user1 = new User("Mirvari", "Muradova", 10, "mirvari@gmail.com", "1234m", UserRole.User);
        User user2 = new User("Farid", "Hasanov", 20, "farid@gmail.com", "f123", UserRole.User);

        adminController.AddAdmin(admin1);
        userController.AddUser(user1);
        userController.AddUser(user2);


        ReEnter:
        Console.Write("Welcome! Choose variant: \n" +
                      "1. Sign Up\n" +
                      "2. Sign In\n" +
                      "Enter your choice: ");
        var userChoice = Console.ReadLine();

        if (int.TryParse(userChoice, out int res))
        {
            int choice = int.Parse(userChoice);
            if (choice == 1)
            {
                ReRole:
                Console.Write("Which role are you: User or Admin? Enter (U/A): ");
                string roleChoice = Console.ReadLine();

                if (roleChoice == "U")
                {
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter your surname: ");
                    string surname = Console.ReadLine();

                    Console.Write("Enter your age: ");
                    var ageCon = Console.ReadLine();
                    int a;
                    bool checkAge = int.TryParse(ageCon, out a);
                    int age = 0;
                    if (checkAge)
                    {
                        age = Convert.ToInt32(ageCon);
                    }
                    else
                    {
                        Console.WriteLine("It is not a number! Enter again");
                    }

                    Console.Write("Enter your email: ");
                    string email = Console.ReadLine();

                    RePass:
                    Console.Write("Enter your password: ");
                    string Camepassword = Console.ReadLine();

                    Console.Write("Enter your password again: ");
                    string CameconfirmPassword = Console.ReadLine();

                    string password;
                    if (Camepassword == CameconfirmPassword)
                    {
                        password = Camepassword;
                    }
                    else
                    {
                        Console.WriteLine("Password didn't match! Enter again");
                        goto RePass;
                    }

                    UserRole userRole = UserRole.User;

                    User user = new User(name, surname, age, email, password, userRole);

                    userController.SignUp(user);
                    userController.ShowProfiles();
                }
                else if (roleChoice == "A")
                {
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter your surname: ");
                    string surname = Console.ReadLine();

                    Console.Write("Enter your age: ");
                    var ageCon = Console.ReadLine();
                    int a;
                    bool checkAge = int.TryParse(ageCon, out a);
                    int age = 0;
                    if (checkAge)
                    {
                        age = Convert.ToInt32(ageCon);
                    }
                    else
                    {
                        Console.WriteLine("It is not a number! Enter again");
                    }

                    Console.Write("Enter your email: ");
                    string email = Console.ReadLine();

                    RePass:
                    Console.Write("Enter your password: ");
                    string Camepassword = Console.ReadLine();

                    Console.Write("Enter your password again: ");
                    string CameconfirmPassword = Console.ReadLine();

                    string password;
                    if (Camepassword == CameconfirmPassword)
                    {
                        password = Camepassword;
                    }
                    else
                    {
                        Console.WriteLine("Password didn't match! Enter again");
                        goto RePass;
                    }

                    UserRole userRole = UserRole.Admin;

                    Admin admin = new Admin(name, surname, age, email, password, userRole);

                    adminController.SignUp(admin);
                    adminController.ShowProfiles();
                }
                else
                {
                    Console.WriteLine("There is not this type! Enter again");
                    goto ReRole;
                }
            }
            else if (choice == 2)
            {
                ReSign:
                Console.WriteLine("What is your role: User or Admin (U/A)? ");
                string role = Console.ReadLine();

                if (role == "U")
                {
                    Console.Clear();
                    Console.Write("Enter your email: ");
                    string email = Console.ReadLine();

                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();

                    bool isSigntrue = userController.SignIn(email, password);
                    
                    if (isSigntrue)
                    {
                        foreach (User user in userController.Users)
                        {
                            if(user.Email == email && user.Password == password)
                            {
                               Console.WriteLine($"Name: {user.Name}\n" +
                                                 $"Surname: {user.Surname}\n" +
                                                 $"Age: {user.Age}\n" +
                                                 $"Email: {user.Email}" +
                                                 $"Password: {user.Password}\n" +
                                                 $"Role: {UserRole.User}"); 
                            }
                            
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Your role is not a user! Enter again");
                        goto ReSign;
                    }
                }
                else if (role == "A")
                {
                    Console.Clear();
                    Console.Write("Enter your email: ");
                    string email = Console.ReadLine();

                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();

                    bool isSigntrue = adminController.SignIn(email, password);
                    if (isSigntrue)
                    {
                        foreach (Admin admin in adminController.Admins)
                        {
                            if (admin.Email == email && admin.Password == password)
                            {
                                Console.WriteLine($"Name: {admin.Name}\n" +
                                                  $"Surname: {admin.Surname}\n" +
                                                  $"Age: {admin.Age}\n" +
                                                  $"Email: {admin.Email}\n" +
                                                  $"Password: {admin.Password}\n" +
                                                  $"Role: {UserRole.Admin}");
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Your role is not a admin! Enter again");
                        goto ReSign;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("There is not this role! Enter again");
                    goto ReSign;
                }
            }
            goto ReEnter;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("It is not integer number! Enter again");
            goto ReEnter;
        }
    }
}