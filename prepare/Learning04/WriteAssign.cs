public class WriteAssign : Assignment
{
    private string _title;

     public WriteAssign(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        string studentName = GetStudentsName();

        return $"{_title} by {studentName}";
    }
}