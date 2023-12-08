using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities.Views;

public partial class MonthlyRevenueAnalysis
{
    public int? TransactionYear { get; set; }

    public int? TransactionMonth { get; set; }

    public decimal? MonthlyRevenue { get; set; }
}
