using System.ComponentModel.DataAnnotations;

namespace StudentData.Contracts.Students;

public class StudentUpdateRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(1, 200)]
    public int Age { get; set; }

    [Required]
    [StringLength(50)]
    public string Branch { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
