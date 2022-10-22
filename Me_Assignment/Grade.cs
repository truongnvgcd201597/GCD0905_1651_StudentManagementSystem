namespace Me_Assignment;

public class Grade
{
    private int gradeOne;
    private int gradeTwo;
    private int demoGrade;
    private String totalGrade;
    public int GradeOne
    {
        get
        {
            return gradeOne;
        }
        set
        {
            if(value < 0 || value > 10)
            {
                throw new ArgumentException("The Grade 1 is not elligible");
            }
            else
            {
                gradeTwo = value;
            }
        }
    }

    public int GradeTwo
    {
        get
        {
            return gradeTwo;
        }
        set
        {
            if(value < 0 || value > 10)
            {
                throw new ArgumentException("The Grade 1 is not elligible");
            }
            else
            {
                gradeTwo = value;
            }
        }
    }

    public int DemoGrade
    {
        get
        {
            return demoGrade;
        }
        set
        {
            if(value < 0 || value > 10)
            {
                throw new ArgumentException("The Grade 1 is not elligible");
            }
            else
            {
                gradeTwo = value;
            }
        }
    }

    public string TotalGrade1
    {
        get
        {
            return totalGrade;
        }
        set
        {
            totalGrade = value;
        }
    }

    public Grade()
    {
    }

    public Grade(int gradeOne, int gradeTwo, int demoGrade)
    {
        this.gradeOne = gradeOne;
        this.gradeTwo = gradeTwo;
        this.demoGrade = demoGrade;
        this.totalGrade = TotalGrade();
    }

    public String TotalGrade()
    {
        double totalGrade = (gradeOne + gradeTwo + demoGrade)/3;
        if (totalGrade< 6) return "Fail";
        if (totalGrade == 6) return "Pass";
        if (totalGrade == 7 || totalGrade == 8) return "Merit";
        return "Distinction";
    }
}