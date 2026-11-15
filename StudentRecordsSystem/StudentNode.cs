public class StudentNode
{
    public Student Data { get; set; }
    public StudentNode? Next { get; set; }

    public StudentNode(Student student)
    {
        Data = student;
        Next = null;
    }
}
