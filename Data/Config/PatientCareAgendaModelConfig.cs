using Healthcare.API.Entities.Procedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareAPI.Data.Config;

public class PatientCareAgendaModelConfig : IEntityTypeConfiguration<PatientCareAgendaModel>
{
    public void Configure(EntityTypeBuilder<PatientCareAgendaModel> builder)
    {
        builder.HasNoKey();
    }
}
