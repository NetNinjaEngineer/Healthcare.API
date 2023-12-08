using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class PharmacyTransaction
{
    public int TransactionId { get; set; }

    public int? PrescriptionId { get; set; }

    public int? MedicineId { get; set; }

    public int? QuantitySold { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public virtual Medicine? Medicine { get; set; }

    public virtual Prescription? Prescription { get; set; }
}
