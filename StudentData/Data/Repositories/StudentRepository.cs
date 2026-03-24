using Microsoft.EntityFrameworkCore;
using StudentData.Models;

namespace StudentData.Data.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentDbContext _dbContext;

    public StudentRepository(StudentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Student>> GetAllAsync()
    {
        return await _dbContext.Students
            .Where(s => !s.IsDeleted)
            .OrderBy(s => s.StudentID)
            .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _dbContext.Students
            .FirstOrDefaultAsync(s => s.StudentID == id && !s.IsDeleted);
    }

    public async Task<Student> CreateAsync(Student student)
    {
        await _dbContext.Students.AddAsync(student);
        await _dbContext.SaveChangesAsync();
        return student;
    }

    public async Task<bool> UpdateAsync(Student student)
    {
        var existing = await _dbContext.Students
            .FirstOrDefaultAsync(s => s.StudentID == student.StudentID && !s.IsDeleted);

        if (existing is null)
        {
            return false;
        }

        existing.Name = student.Name;
        existing.Age = student.Age;
        existing.Branch = student.Branch;
        existing.Email = student.Email;

        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var existing = await _dbContext.Students
            .FirstOrDefaultAsync(s => s.StudentID == id && !s.IsDeleted);

        if (existing is null)
        {
            return false;
        }

        existing.IsDeleted = true;
        existing.DeletedAtUtc = DateTimeOffset.UtcNow;

        await _dbContext.SaveChangesAsync();
        return true;
    }
}
