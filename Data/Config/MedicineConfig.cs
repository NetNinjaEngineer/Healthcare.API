using Healthcare.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareAPI.Data.Config;

public class MedicineConfig : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.Property(x => x.Image)
            .HasColumnName("Image")
            .HasColumnType("VARBINARY(MAX)")
            .IsRequired(false);

        builder.Property(x => x.ImagePath)
           .HasColumnName("ImagePath")
           .HasColumnType("VARCHAR")
           .IsRequired(false);
    }
}
