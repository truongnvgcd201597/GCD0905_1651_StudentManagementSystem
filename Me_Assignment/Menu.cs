namespace Me_Assignment;

public class Menu
{
    public virtual void showMenu()
    {
        Console.WriteLine("1. Add a new student");
        Console.WriteLine("2. Display all students");
        Console.WriteLine("3. Search for a student");
        Console.WriteLine("4. Exit");
    }

    public virtual void userLogin()
    {
        Console.WriteLine("Please enter your username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Please enter your password: ");
        string password = Console.ReadLine();

        if (username == "admin" && password == "admin")
        {
            Console.WriteLine("Login successful");
        }
        else
        {
            Console.WriteLine("Login failed");
        }
    }
}