using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities.Views;

public partial class GetMedicinesWithUnitPrice
{
    public string Medicine { get; set; } = null!;

    public decimal UnitPrice { get; set; }
}
