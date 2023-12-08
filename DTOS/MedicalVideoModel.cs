namespace Healthcare.API.DTOS;

public class MedicalVideoModel
{
    public string? Path { get; set; }
    public string? Title { get; set; }
    public IFormFile? Video { get; set; }
    public string? Description { get; set; }
    public int? DepartmentId { get; set; }
}
