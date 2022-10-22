namespace Me_Assignment;

public class Class
{
    private String className;

    public string ClassName
    {
        get
        {
            return className;
        }
        set
        {
            if(value.Length != 7)
            {
                Console.WriteLine("Class name is not vaild");
            }
            else
            {
                className = value;
            }
        }
    }

    public Class(string className)
    {
        this.ClassName = className;
    }
}