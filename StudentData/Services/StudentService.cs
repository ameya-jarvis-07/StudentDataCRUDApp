using StudentData.Contracts.Students;
using StudentData.Data.Repositories;
using StudentData.Models;

namespace StudentData.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IReadOnlyList<StudentResponse>> GetAllAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        return students.Select(MapToResponse).ToList();
    }

    public async Task<StudentResponse?> GetByIdAsync(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        return student is null ? null : MapToResponse(student);
    }

    public async Task<StudentResponse> CreateAsync(StudentCreateRequest request)
    {
        var student = new Student
        {
            Name = request.Name,
            Age = request.Age,
            Branch = request.Branch,
            Email = request.Email,
            IsDeleted = false,
            DeletedAtUtc = null
        };

        var created = await _studentRepository.CreateAsync(student);
        return MapToResponse(created);
    }

    public async Task<bool> UpdateAsync(int id, StudentUpdateRequest request)
    {
        var student = new Student
        {
            StudentID = id,
            Name = request.Name,
            Age = request.Age,
            Branch = request.Branch,
            Email = request.Email
        };

        return await _studentRepository.UpdateAsync(student);
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        return await _studentRepository.SoftDeleteAsync(id);
    }

    private static StudentResponse MapToResponse(Student student)
    {
        return new StudentResponse
        {
            StudentID = student.StudentID,
            Name = student.Name,
            Age = student.Age,
            Branch = student.Branch,
            Email = student.Email
        };
    }
}
