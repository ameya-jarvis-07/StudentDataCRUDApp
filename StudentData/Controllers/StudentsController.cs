using Microsoft.AspNetCore.Mvc;
using StudentData.Contracts.Students;
using StudentData.Services;

namespace StudentData.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<StudentResponse>>> GetAll()
    {
        var students = await _studentService.GetAllAsync();
        return Ok(students);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<StudentResponse>> GetById(int id)
    {
        var student = await _studentService.GetByIdAsync(id);
        if (student is null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<StudentResponse>> Create([FromBody] StudentCreateRequest request)
    {
        var created = await _studentService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.StudentID }, created);
    }

    [HttpPost("{id:int}/update")]
    public async Task<IActionResult> Update(int id, [FromBody] StudentUpdateRequest request)
    {
        var updated = await _studentService.UpdateAsync(id, request);
        if (!updated)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPost("{id:int}/delete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var deleted = await _studentService.SoftDeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}
