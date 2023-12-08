using System.ComponentModel.DataAnnotations;

namespace Healthcare.API.Entities.Procedures;

public class AddEmployeeToDepartmentModel
{
    public int DepartmentId { get; set; }
    [RegularExpression(@"^[a-zA-Z]+$")]
    public string? FirstName { get; set; }
    [RegularExpression(@"^[a-zA-Z]+$")]
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public string? JobTitle { get; set; }
    public decimal Salary { get; set; }
    public string? Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
}
