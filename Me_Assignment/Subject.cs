namespace Me_Assignment;

public class Subject
{
    private String subject;
    private List<Subject> subjects = new List<Subject>();
    public string Subject1
    {
        get
        {
            return subject;
        }
        set
        {
            subject = value;
        }
    }

    public Subject(string subject)
    {
        this.subject = subject;
    }
}