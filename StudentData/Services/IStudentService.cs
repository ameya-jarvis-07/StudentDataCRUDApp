using StudentData.Contracts.Students;

namespace StudentData.Services;

public interface IStudentService
{
    Task<IReadOnlyList<StudentResponse>> GetAllAsync();
    Task<StudentResponse?> GetByIdAsync(int id);
    Task<StudentResponse> CreateAsync(StudentCreateRequest request);
    Task<bool> UpdateAsync(int id, StudentUpdateRequest request);
    Task<bool> SoftDeleteAsync(int id);
}
