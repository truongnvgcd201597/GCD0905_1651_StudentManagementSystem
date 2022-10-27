namespace Me_Assignment;
public class Manager : AMenu
{
    private int ID;
    private String managerName;
    private int manaPhone;
    private static List<Student> studentList = new List<Student>();

    public static List<Student> StudentList
    {
        get => studentList;
        set => studentList = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Manager(int id, string managerName, int manaPhone)
    {
        ID = id;
        this.managerName = managerName;
        this.manaPhone = manaPhone;
    }

    public Manager()
    {
    }

    public override void showMenu()
    {
        Console.WriteLine(" ======================================= ADMIN PANEL =============================================");
        Console.WriteLine("| 1: Add student information    | 2: View all student information | 3: Update student information |");
        Console.WriteLine("|_______________________________|_________________________________|_______________________________|");
        Console.WriteLine("| 4: Delete student information | 5: Update student grade         | 6: Add subject                |");
        Console.WriteLine("|_______________________________|_________________________________|_______________________________|");
        Console.WriteLine("| 7: View subject               | 8: Remove subject               | 9: Add class                  |");
        Console.WriteLine("|_______________________________|_________________________________|_______________________________|");
        Console.WriteLine("| 10: Remove class              | 11: View class                  | 12: Search student profile    |");
        Console.WriteLine("|_______________________________|_________________________________|_______________________________|");
        Console.WriteLine("| 13: Sort students by grades   | 15: Exit                        |           NVTRUONG96          |");
        Console.WriteLine("|_______________________________|_________________________________|_______________________________|");
        Console.Write("Enter your choice: ");
        int choice = Int32.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                addStudentProfile();
                break;
            case 2:
                viewStudentProfile();
                break;
            case 3:
                modifyStudentProfile();
                break;
            case 4:
                deleteStudentProfile();
                break;
            case 5:
                editStudentGrade();
                break;
            case 6:
                addSubject();
                break;
            case 7:
                viewSubject();
                break;
            case 8:
                removeSubject();
                break;
            case 9:
                addClass();
                break;
            case 10:
                removeClass();
                break;
            case 11:
                viewClass();
                break;
            case 12:
                searchStudentProfile();
                break;
            case 13:
                descascStudentGrade();
                break;
            case 14:
                User user = new User();
                user.viewSystem();
                break;
            default:
                showMenu();
                break;
        }
    }

    public override void userLogin()
    {
        while (true)
        {
            Console.Write("Username: ");
            String username = Console.ReadLine().ToLower();
            Console.Write("Password: ");
            String password = Console.ReadLine().ToLower();

            if (username == "truongnvgcd201597" && password == "123123")
            {
                showMenu();
            }
            else
            {
                Console.WriteLine("Username or password wrong!!!");
            }
        }
    }
//CASE 1
 public void addStudentProfile()
    {
        if (Student.classList.Count == 0)
        {
            Console.WriteLine("Empty class");
            addClass();
        }
        else if (Student.subjectList.Count == 0)
        {
            Console.WriteLine("Empty subject");
            addSubject();
        }

        Console.Write("Enter student's class: ");
        String studentClass = Console.ReadLine().ToUpper();
        while (existInList(studentClass) == false)
        {
            Console.Write("Class doesn't exist, try again: ");
            studentClass = Console.ReadLine().ToUpper();
        }

        Console.Write("Enter student's ID: ");
        String studentID = Console.ReadLine().ToUpper();
        while (checkExistStudentID(studentID) == true || formatID(studentID) == false)
        {
            Console.Write("Exist ID or incorrect format, re-enter (eg:GCD201597,...): ");
            String studentIDs = Console.ReadLine().ToUpper();
            studentID = studentIDs;
        }

        Console.Write("Enter student's name: ");
        String studentName = Console.ReadLine();
        while (checkName(studentName) == false)
        {
            Console.WriteLine("Invalid input name");
            Console.Write("Enter student's name: ");
            String studentNames = Console.ReadLine();
            studentName = studentNames;
        }
        Console.Write("Enter student's address: ");
        String studentAddress = Console.ReadLine();
        Console.Write("Enter student's day of birth: ");
        String[] studentDOB = Console.ReadLine().Split('/');
        int day = int.Parse(studentDOB[0]);
        int month = int.Parse(studentDOB[1]);
        int year = int.Parse(studentDOB[2]);
        while (checkDate(day, month, year) == false)
        {
            Console.WriteLine("Invalid birthdate");
            Console.Write("Enter student's day of birth: ");
            String[] studentDOBs = Console.ReadLine().Split('/');
            int days = int.Parse(studentDOBs[0]);
            int months = int.Parse(studentDOBs[1]);
            int years = int.Parse(studentDOBs[2]);
            day = days;
            month = months;
            year = years;
        }
        Console.Write("Enter subject: ");
        String subject = Console.ReadLine();
        while (existInSubject(subject) == false)
        {
            Console.WriteLine("Subject not exist ... Please enter new subject");
            Console.Write("Enter subject:");
            string subjectNew = Console.ReadLine();
            subject = subjectNew;
        }
        Console.Write("Enter GradeOne's grade: ");
        int gradeOne = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter GradeTwo's grade: ");
        int gradeTwo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Implemention Tests's grade: ");
        int demoGrade = Convert.ToInt32(Console.ReadLine());
        while (checkGrade(gradeOne, gradeTwo, demoGrade) == false)
        {
            Console.WriteLine("Invalid input grade");
            Console.Write("Enter GradeOne's grade: ");
            int gradeOnes = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter GradeTwo's grade: ");
            int gradeTwos = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Implemention Tests's grade: ");
            int demoGrades = Convert.ToInt32(Console.ReadLine());
            gradeOne = gradeOnes;
            gradeTwo = gradeTwos;
            demoGrade = demoGrades;
        }
        try
        {
            studentList.Add(new Student(new Class(studentClass), studentID, studentName, studentAddress,
                new DateOnly(year, month, day),
                new Subject(subject), new Grade(gradeOne, gradeTwo, demoGrade)));
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            showMenu();
        }

        Console.WriteLine("Added Successfully!!");
        Console.WriteLine("(Y)es to add continue / Press any key to exit)");
        String choice = Console.ReadLine().ToUpper();
        switch (choice)
        {
            case "Y":
                addStudentProfile();
                break;
            default:
                showMenu();
                break;
        }
    }
// CASE 2:
    public void viewStudentProfile()
    {
        foreach (Student std in studentList)
        {
            Console.WriteLine($"Password: {std.studentHash}| ID: {std.studentID} | Name: {std.name} | Birthdate: {std.birthDate} |\n" +
                              $"Address: {std.studentAddress} | Class: {std.Classroom.ClassName} | Subject: {std.Subject.Subject1} |\n" +
                              $"{std.StudentGrade.GradeOne} | Grade Two: {std.StudentGrade.GradeTwo} | DemoGrade: {std.StudentGrade.DemoGrade} | Total Grade: {std.StudentGrade.TotalGrade1}|");
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
//CASE 3:
    public void deleteStudentProfile()
    {
        Console.Write("Enter studentID that you want to delete: ");
        String delStudent = Console.ReadLine().ToUpper();
        if (studentList.Exists(x => x.studentID == delStudent))
        {
            studentList.Remove(studentList.SingleOrDefault(q => q.studentID == delStudent));
            Console.WriteLine("Delete successfully");
            showMenu();
        }
        else
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("No student matches to your input, please try again!");
            Console.WriteLine("-----------------------------------------");
            deleteStudentProfile();
        }
    }
//CASE 4:
    public void modifyStudentProfile()
    {
        Console.Write("Enter studentID that you want to modify: ");
        String modStudent = Console.ReadLine().ToUpper();
        if (studentList.Exists(x => x.studentID == modStudent))
        {
            Console.Write("Enter part that you want to modify (Delete only 'class' and 'address' and 'password'): ");
            String modPart = Console.ReadLine().ToLower();
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].studentID == modStudent)
                {
                    Student student = studentList[i];
                    switch (modPart.ToLower())
                    {
                        case "class":
                            Console.Write("Enter student's new class: ");
                            student.Classroom.ClassName = Console.ReadLine();
                            break;
                        case "address":
                            Console.Write("Enter student's new address: ");
                            student.studentAddress = Console.ReadLine();
                            break;
                        case "password":
                            Console.Write("Enter student's new password: ");
                            student.studentHash = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invalid ");
                            modifyStudentProfile();
                            break;
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("No student matches to your input, please try again!");
            Console.WriteLine("-----------------------------------------");
            modifyStudentProfile();
        }

        showMenu();
    }
    public void removeClass()
    {
        Console.Write("Enter class that you want to delete: ");
        String className = Console.ReadLine();
        var itemToRemove = Student.classList.SingleOrDefault(r => r.ClassName == className);
        if (itemToRemove != null)
        {
            Student.classList.Remove(itemToRemove);
            showMenu();
        }
        else
        {
            Console.WriteLine("Please re-enter");
            removeClass();
        }

        //display list
        foreach (var item in Student.classList)
        {
            Console.Write("{0} (project) -- ", item.ClassName);
        }
    }

    public void addSubject()
    {
        try{
        Console.WriteLine("++++++++++++++++++++");
        Console.Write("Enter the quantity that you want to add: ");
        int quantityChoice = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < quantityChoice; i++)
        {
            Console.Write("Enter subject name: ");
            String subjectName = Console.ReadLine();
            Student.subjectList.Add(new Subject(subjectName));
        }

        Console.WriteLine("ADD SUCCESSFULLY");
        Console.WriteLine("++++++++++++++++++++");
        showMenu();
        }catch(Exception e){
            Console.WriteLine("Please enter the correct format");
            addSubject();
        }
    }

    public void viewSubject()
    {
        foreach (var i in Student.subjectList)
        {
            Console.WriteLine(i.Subject1);
        }

        showMenu();
    }

    public void removeSubject()
    {
        Console.Write("Enter name of subject that you want to delete: ");
        String delStudent = Console.ReadLine();
        if (Student.subjectList.Exists(x => x.Subject1 == delStudent))
        {
            Student.subjectList.Remove(Student.subjectList.SingleOrDefault(q => q.Subject1 == delStudent));
            Console.WriteLine("Delete successfully");
            showMenu();
        }
        else
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("No student matches to your input, please try again!");
            Console.WriteLine("-----------------------------------------");
            removeSubject();
        }
    }

    public void editStudentGrade()
    {
        Console.Write("Enter studentID that you want to edit grade: ");
        String id = Console.ReadLine().ToUpper();
        if (studentList.Exists(x => x.studentID == id))
        {
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].studentID == id)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Subject name: " + Student.subjectList[i].Subject1);
                    Console.Write("Enter first grade for student");
                    int one = Int32.Parse(Console.ReadLine());
                    Console.Write("Enter second grade for student");
                    int two = Int32.Parse(Console.ReadLine());
                    Console.Write("Enter test grade");
                    int test = Int32.Parse(Console.ReadLine());
                    studentList[i].StudentGrade.GradeOne = one;
                    studentList[i].StudentGrade.GradeTwo = two;
                    studentList[i].StudentGrade.DemoGrade = test;
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Successful");
                    Console.WriteLine("-----------------------------------");
                }
            }
        }
        else
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("No student matches to your input, please try again!");
            Console.WriteLine("-----------------------------------------");
            editStudentGrade();
        }

        showMenu();
    }

    public void viewStudentGrade()
    {
        Console.WriteLine("Enter studentID that you want to view all grade:");
        String viewGrade = Console.ReadLine();
    }

    public void addClass()
    {
        Console.WriteLine("++++++++++++++++++++");
        Console.Write("Enter the quantity that you want to add: ");
        try{
        int quantityChoice = Int32.Parse(Console.ReadLine().ToUpper());
        for (int i = 0; i < quantityChoice; i++)
        {
            Console.Write("Enter class name: ");
            String className = Console.ReadLine().ToUpper();
            while (existInList(className) == true || formatClass(className) == false)
            {
                Console.WriteLine(
                    "Class name already exist or incorrect standard name, please retry again! (eg: GCD0905, gcd0905)");
                Console.Write("Enter class name: ");
                String classNameRef = Console.ReadLine().ToUpper();
                className = classNameRef;
            }

            Student.classList.Add(new Class(className));
        }}catch(Exception e){
            Console.WriteLine("Please enter number");
            addClass();
        }

        Console.WriteLine("ADD SUCCESSFULLY");
        Console.WriteLine("++++++++++++++++++++");
        showMenu();
    }

    public void viewClass()
    {
        foreach (var i in Student.classList)
        {
            Console.WriteLine(i.ClassName);
        }

        showMenu();
    }

    public void searchStudentProfile()
    {
        Console.WriteLine("Enter student ID:");
        String id = Console.ReadLine();
        foreach (Student std in studentList)
        {
            if (studentList.Exists(x => x.studentID == id))
            {
                Console.WriteLine($"ID: {std.studentID} | Name: {std.name} | Birthdate: {std.birthDate} |\n" +
                                  $"Address: {std.studentAddress} | Class: {std.Classroom.ClassName} | Subject: {std.Subject.Subject1} |\n" +
                                  $"{std.StudentGrade.GradeOne} | Grade Two: {std.StudentGrade.GradeTwo} | DemoGrade: {std.StudentGrade.DemoGrade} | Total Grade: {std.StudentGrade.TotalGrade1} |");
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

    public void descascStudentGrade()
    {
        Console.WriteLine("Select option to rank (grade or birthdate): ");
        String Choice = Console.ReadLine();
        //order by descending student and print
        if (Choice == "grade")
        {
            var sortedList = studentList.OrderByDescending(x => x.StudentGrade.TotalGrade1).ToList();
            foreach (var i in sortedList)
            {
                Console.WriteLine(i.studentID + "-" + i.name + "-" + i.age.ToString() + "-" + i.studentAddress + "-" +
                                  i.Classroom.ClassName + "-" + i.Subject.Subject1 + "-" + i.StudentGrade.GradeOne +
                                  "-" + i.StudentGrade.GradeTwo + "-" + i.StudentGrade.DemoGrade + "-" +
                                  i.StudentGrade.TotalGrade1);
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
        else if (Choice == "birthdate")
        {
            var sortedList = studentList.OrderByDescending(x => x.birthDate).ToList();
            foreach (var i in sortedList)
            {
                Console.WriteLine(i.studentID + "-" + i.name + "-" + i.studentAddress + "-" +
                                  i.Classroom.ClassName + "-" + i.Subject.Subject1 + "-" + i.StudentGrade.GradeOne
                                  + "-" + i.birthDate +
                                  "-" + i.StudentGrade.GradeTwo + "-" + i.StudentGrade.DemoGrade + "-" +
                                  i.StudentGrade.TotalGrade1);
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
    }

    private Boolean existInList(String className)
    {
        if (Student.classList.Exists(x => x.ClassName == className)) return true;
        else return false;
    }

    private Boolean formatClass(String className)
    {
        if (className.StartsWith("GCD") && className.Length == 7) return true;
        else return false;
    }

    private Boolean existInSubject(String subject)
    {
        if (Student.subjectList.Exists(x => x.Subject1 == subject)) return true;
        else return false;
    }

    private Boolean checkExistStudentID(String studentID)
    {
        if (studentList.Exists(x => x.studentID == studentID)) return true;
        else return false;
    }

    private Boolean formatID(String studentID)
    {
        if (studentID.Length == 9 && studentID.StartsWith("GCD")) return true;
        else return false;
    }

    private Boolean checkDate(int day, int month, int year)
    {
        if ((day > 0 && day < 31) && (month > 0 && month < 12) && (year > 1935 && year < 2004)) return true;
        else return false;
    }
    //check grade
    private Boolean checkGrade(int grade , int grade2 , int grade3)
    {
        if ((grade > 0 && grade < 10) && (grade2 > 0 && grade2 < 10) && (grade3 > 0 && grade3 < 10)) return true;
        else return false;
    }
    private Boolean checkName(String name){
        if(typeof(String) == name.GetType()) return true;
        else return false;
    }

}