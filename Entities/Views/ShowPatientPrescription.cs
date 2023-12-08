using System;
using System.Collections.Generic;

namespace HealthCareAPI.Models.Views;

public partial class ShowPatientPrescription
{
    public string Patient { get; set; } = null!;

    public string MedicineName { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public string Times { get; set; } = null!;

    public string Diagnosis { get; set; } = null!;

    public string Doctor { get; set; } = null!;
}
