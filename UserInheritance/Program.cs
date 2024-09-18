using System;
using UserInheritance;

public class Program
{
    public static void Main(string[] args)
    {
        ProfileController profileController = new ProfileController();
        
        Admin admin1 = new Admin("Zahra", "Malikzada", 12,  "zahra@gmail.com", "1234", UserRole.Admin);
        User user1 = new User("Mirvari", "Muradova", 10, "mirvari@gmail.com", "1234m", UserRole.User);
        User user2 = new User("Farid", "Hasanov", 20, "farid@gmail.com", "f123", UserRole.User);

        
        profileController.AddProfile(admin1);
        profileController.AddProfile(user1);
        profileController.AddProfile(user2);

        
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

                    profileController.SignUp(user);
                    profileController.ShowAllProfiles();
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

                    profileController.SignUp(admin);
                    profileController.ShowAllProfiles();
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
                Console.Write("Enter your email: ");
                string email = Console.ReadLine();

                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                
                bool isSigntrue = profileController.SignIn(email, password);

                if (isSigntrue)
                {
                    bool answer = profileController.CheckingRole(email, password);
                    if (answer)
                    {
                        ReChoice:
                        Console.Write("What to do? Choose: \n" +
                                      "1. Show profiles \n" +
                                      "2. Add profile\n" +
                                      "Enter your choice: ");
                        var signChoice = Console.ReadLine();
                        int b;
                        bool checkSign = int.TryParse(signChoice, out b);
                        int adminChoice = 0;
                        if (checkSign)
                        {
                            adminChoice = Convert.ToInt32(signChoice);
                            if (adminChoice == 1)
                            {
                                profileController.ShowAllProfiles();
                            }
                            else if (adminChoice == 2)
                            {
                                Console.Write("Enter name: ");
                                string name = Console.ReadLine();

                                Console.Write("Enter surname: ");
                                string surname = Console.ReadLine();

                                ReAge:
                                Console.Write("Enter age: ");
                                var enteredAge = Console.ReadLine();
                                int c;
                                bool checkAge = int.TryParse(enteredAge, out c);
                                int age = 0;
                                if (checkAge)
                                {
                                    age = Convert.ToInt32(enteredAge);
                                }
                                else
                                {
                                    Console.WriteLine("It is not integer! Enter again");
                                    goto ReAge;
                                }

                                Console.Write("Enter email: ");
                                string adminEnteredEmail = Console.ReadLine();

                                Console.Write("Enter password: ");
                                string adminEnteredPassword = Console.ReadLine();
                                
                                ReEnterRole:
                                Console.WriteLine("Which role do you want to create: User or Admin (U/A): ");
                                string adminAnswer = Console.ReadLine();
                                UserRole userRole;
                                if (adminAnswer == "U")
                                {
                                    Profile user = new User(name, surname, age, adminEnteredEmail, adminEnteredPassword,
                                        UserRole.User);
                                    profileController.AddProfile(user);
                                    profileController.ShowAllProfiles();
                                }
                                else if (adminAnswer == "A")
                                {
                                    Profile admin = new Admin(name, surname, age, adminEnteredEmail, adminEnteredPassword,
                                        UserRole.Admin);
                                    profileController.AddProfile(admin);
                                    profileController.ShowAllProfiles();
                                }
                                else
                                {
                                    Console.WriteLine("There is not this variant! Enter again");
                                    goto ReEnterRole;
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is not this variant! Enter again");
                                goto ReChoice;
                            }
                        }
                        else
                        {
                            Console.WriteLine("It is not inteter number! Enter again");
                            goto ReChoice;
                        }
                    }
                    else
                    {
                        foreach (Profile profile in profileController.Profiles)
                        {
                            if (profile.Email == email && profile.Password == password && profile is User user)
                            {
                                Console.WriteLine($"Name: {user.Name}\n" +
                                                  $"Surname: {user.Surname}\n" +
                                                  $"Age: {user.Age}");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong email or password");
                    goto ReSign;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There is not this variant! Enter again");
                goto ReEnter;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("It is not integer number! Enter again");
            goto ReEnter;
        }
    }
}