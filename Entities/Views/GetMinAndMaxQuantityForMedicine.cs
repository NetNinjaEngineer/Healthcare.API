namespace Healthcare.API.Entities.Views;

public partial class GetMinAndMaxQuantityForMedicine
{
    public string Medicine { get; set; } = null!;

    public int CurrentQuantity { get; set; }
}
