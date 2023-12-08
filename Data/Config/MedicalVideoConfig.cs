using Healthcare.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareAPI.Data.Config;

public class MedicalVideoConfig : IEntityTypeConfiguration<MedicalVideo>
{
    public void Configure(EntityTypeBuilder<MedicalVideo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .HasColumnType("VARCHAR(100)")
            .HasColumnName("Title").IsRequired();

        builder.Property(x => x.Description)
            .HasColumnType("VARCHAR(500)")
            .HasColumnName("Description").IsRequired();

        builder.Property(x => x.Path)
            .HasColumnType("VARCHAR(255)")
            .HasColumnName("Path").IsRequired();

        builder.Property(x => x.Video)
            .HasColumnType("VARBINARY(MAX)")
            .HasColumnName("Video").IsRequired();

        builder.HasOne(x => x.Department)
            .WithMany(x => x.MedicalVideos)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull).IsRequired(false);

    }
}
