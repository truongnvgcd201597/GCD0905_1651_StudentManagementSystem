namespace Me_Assignment;

public class User
{
    public void viewSystem()
    {
        Console.WriteLine("STUDENT MANAGEMENT SYSTEM"); 
        Console.WriteLine("1. Student login");
        Console.WriteLine("2. Admintrator login");
        Console.WriteLine("3. Exit");
        try
        {
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Student student = new Student();
                    student.userLogin();
                    break;
                case 2:
                    Manager manager = new Manager();
                    manager.userLogin();
                    break;
                case 3:
                    Console.WriteLine("Exit");
                    break;
                default:
                    viewSystem();
                    break;
            }
        }catch(Exception e)
        {
            Console.WriteLine("Invalid choice!!!");
            viewSystem();
        }
    }
}