namespace Healthcare.API.Entities.Views;

public partial class GetAgesForHiredEmployee
{
    public string Employee { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public int? Age { get; set; }
}
