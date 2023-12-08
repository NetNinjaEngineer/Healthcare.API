using Healthcare.API.Entities.Procedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareAPI.Data.Config;

public class MedicinesSuppliedByModelConfig : IEntityTypeConfiguration<MedicinesSuppliedByModel>
{
    public void Configure(EntityTypeBuilder<MedicinesSuppliedByModel> builder)
    {
        builder.HasNoKey();
    }
}