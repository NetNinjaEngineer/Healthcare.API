namespace Healthcare.API.Entities.Views;

public partial class GetMinAndMaxUnitPriceForMedicine
{
    public string Medicine { get; set; } = null!;

    public decimal UnitPrice { get; set; }
}
