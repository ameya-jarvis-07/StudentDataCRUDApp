namespace StudentData.Contracts.Students;

public class StudentResponse
{
    public int StudentID { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Branch { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
