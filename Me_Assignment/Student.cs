using System.Security.Cryptography;
using System.Text;

namespace Me_Assignment;

public class Student: IMenu
{
    public string studentHash { get; set; }
    public string studentID { get; set; }
    public string name { get; set; }
    public int age { get; set; }
    public String saveOn;
    public string studentAddress { get; set; }
    public DateOnly birthDate { get; set; }
    public Grade studentGrade { get; set; }
    public Class studentClass { get; set; }

    public Subject studentSubject { get; set; }

    //create List instance
    private static List<Subject> subjects = new List<Subject>();
    private static List<Class> classes = new List<Class>();

    // Create Properties
    public static List<Subject> subjectList
    {
        get { return subjects; }
        set { subjects = value; }
    }

    public static List<Class> classList
    {
        get { return classes; }
        set { classes = value; }
    }

    internal Class Classroom
    {
        get => studentClass;
        set => studentClass = value;
    }

    internal Subject Subject
    {
        get => studentSubject;
        set => studentSubject = value;
    }

    internal Grade StudentGrade
    {
        get => studentGrade;
        set => studentGrade = value;
    }

    public Student(Class studentClass, string studentId, string name, string address, DateOnly birthDate,
        Subject studentSubject, Grade studentGrade)
    {
        this.studentHash = GetRandomPassword(10);
        this.studentGrade = studentGrade;
        this.studentClass = studentClass;
        this.studentID = studentId;
        this.birthDate = birthDate;
        this.name = name;
        this.studentAddress = address;
        this.studentSubject = studentSubject;
    }

    public Student()
    {
    }

    public void showMenu()
    {
        Console.WriteLine(" ==========================STUDENT PANEL==========================");
        Console.WriteLine(" |________________________________________________________________|");
        Console.WriteLine(" |              1: View all student information                   |");
        Console.WriteLine(" |________________________________________________________________|");
        Console.WriteLine(" |              2: View grade                                     |");
        Console.WriteLine(" |________________________________________________________________|");
        Console.WriteLine(" |              3: Change password                                |");
        Console.WriteLine(" |________________________________________________________________|");
        Console.WriteLine(" |              4: Exit                                           |");
        Console.WriteLine(" |________________________________________________________________|");
        Console.Write("Enter your choice: ");
        int choice = Int32.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                viewStudentProfile();
                break;
            case 2:
                viewStudentGrade();
                break;
            case 3:
                changePassword();
                break;
            case 4:
                User user = new User();
                user.viewSystem();
                break;
            default:
                Console.WriteLine("Invalid choice!!!");
                break;
        }
    }

    public void userLogin()
    {
        Console.Write("Username : ");
        String username = Console.ReadLine().ToUpper();
        Console.Write("Password: ");
        String password = Console.ReadLine();
        Console.WriteLine(username + ' ' + password);
        foreach (var i in Manager.StudentList)
        {
            if (password.Equals(i.studentHash) && username.Equals(i.studentID))
            {
                saveOn = username;
                Console.WriteLine("Login successful");
                showMenu();
            }
            else
            {
                Console.WriteLine("Login failed");
            }
        }
    }

    public bool validateAccount(String userid, String password)
    {
        //if student id and password of student match with user input then return true
        if (this.studentID == userid && this.studentHash == password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void viewStudentProfile()
    {
        //show student information of student who is logged in
        foreach (var i in Manager.StudentList)
        {
            if (i.studentID == saveOn)
            {
                Console.WriteLine($"Password: {i.studentHash} | ID: {i.studentID} | Name: {i.name} | Birthdat: {i.birthDate} |\n" +
                                  $"Address: {i.studentAddress} | Class: {i.Classroom.ClassName} | Subject: {i.Subject.Subject1} |\n" +
                                  $"{i.StudentGrade.GradeOne} | Grade Two: {i.StudentGrade.GradeTwo} | DemoGrade: {i.StudentGrade.DemoGrade} | Total Grade: {i.StudentGrade.TotalGrade1} |)");
            }
        }
        Console.WriteLine("============================");
        Console.WriteLine("Press any key to exit)");
        String choice = Console.ReadLine().ToUpper();
        switch (choice)
        {
            default:
                showMenu();
                break;
        }
    }

    public void viewStudentGrade()
    {
        foreach (var i in Manager.StudentList)
        {
            if (i.studentID == saveOn)
            {
                Console.WriteLine(
                    $"Grade One: {i.StudentGrade.GradeOne} | Grade Two: {i.StudentGrade.GradeTwo} | DemoGrade: {i.StudentGrade.DemoGrade} | Total Grade: {i.StudentGrade.TotalGrade1}");
            }
        }
        Console.WriteLine("============================");
        Console.WriteLine("Press any key to exit)");
        String choice = Console.ReadLine().ToUpper();
        switch (choice)
        {
            default:
                showMenu();
                break;
        }
    }

    public void changePassword()
    {
        Console.Write("Enter new password:");
        String password = Console.ReadLine();
        foreach (var i in Manager.StudentList)
        {
            if (i.studentID == saveOn)
            {
                i.studentHash = password;
            }
        }
        Console.WriteLine("============================");
        Console.WriteLine("Press any key to exit)");
        String choice = Console.ReadLine().ToUpper();
        switch (choice)
        {
            default:
                userLogin();
                break;
        }
    }
    public static string GetRandomPassword(int length)
    {
        byte[] rgb = new byte[length];
        RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider();
        rngCrypt.GetBytes(rgb);
        return Convert.ToBase64String(rgb);
    }
}