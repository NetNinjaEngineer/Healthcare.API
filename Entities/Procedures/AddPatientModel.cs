using System.ComponentModel.DataAnnotations;

namespace Healthcare.API.Entities.Procedures;

public class AddPatientModel
{
    [RegularExpression(@"^[A-Za-z]+$")]
    public string? FirstName { get; set; }

    [RegularExpression(@"^[A-Za-z]+$")]
    public string? LastName { get; set; }
    public string? Gender { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
