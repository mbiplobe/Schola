using Schola.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Schola.Infrastructure.EF.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<UserReadModel>
{

    public void Configure(EntityTypeBuilder<UserReadModel> builder)
    {
        builder.ToTable("users");
        builder.HasKey(pl => pl.ID);

        builder.Property(x => x.FirstName)
        .HasColumnName("First_Name")
                 .HasMaxLength(100)
                 .IsRequired();
        ;

        builder.Property(x => x.MiddleName)
            .HasColumnName("Middle_Name")
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .HasColumnName("Last_Name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Email);

        builder.Property(x => x.Mobile);

        builder.Property(x => x.Password);

        // builder.Property(x => x.IsActive);

    }


}
