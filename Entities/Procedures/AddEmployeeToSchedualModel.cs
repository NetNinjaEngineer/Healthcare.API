using System.ComponentModel.DataAnnotations;

namespace Healthcare.API.Entities.Procedures;

public class AddEmployeeToSchedualModel
{
    public int DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    [RegularExpression(@"^[a-z A-Z]+$")]
    public string? FirstName { get; set; }
    [RegularExpression(@"^[a-z A-Z]+$")]
    public string? LastName { get; set; }
    public string? Gender { get; set; }

    [RegularExpression(@"^[a-z A-Z]+$")]
    public string? JobTitle { get; set; }
    public string? Phone { get; set; }

    public decimal Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int DepartmentId { get; set; }
}
