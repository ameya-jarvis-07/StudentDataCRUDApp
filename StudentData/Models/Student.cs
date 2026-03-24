namespace StudentData.Models;

public class Student
{
    public int StudentID { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Branch { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTimeOffset? DeletedAtUtc { get; set; }
    public bool IsDeleted { get; set; }
}
