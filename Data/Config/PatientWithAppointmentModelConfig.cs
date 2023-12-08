using Healthcare.API.Entities.Procedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareAPI.Data.Config;

public class PatientWithAppointmentModelConfig : IEntityTypeConfiguration<PatientWithAppointmentModel>
{
    public void Configure(EntityTypeBuilder<PatientWithAppointmentModel> builder)
    {
        builder.HasNoKey();
    }
}
