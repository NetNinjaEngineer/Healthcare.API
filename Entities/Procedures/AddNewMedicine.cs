using System.ComponentModel.DataAnnotations;

namespace Healthcare.API.Entities.Procedures;

public class AddNewMedicine
{
    [RegularExpression(@"^[a-zA-Z]+$")]
    public string? Name { get; set; }
    public DateTime ExpireDate { get; set; }
    public int StockQuantity { get; set; }
    public decimal UnitPrice { get; set; }
    public int CurrentQuantity { get; set; }
}
