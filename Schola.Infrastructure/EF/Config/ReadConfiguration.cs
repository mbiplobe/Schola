using Schola.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Schola.Infrastructure.EF.Config;

    internal sealed class ReadConfiguration : IEntityTypeConfiguration<UserReadModel>
    {

    public void Configure(EntityTypeBuilder<UserReadModel> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(pl => pl.ID);

        builder.Property(x => x.FullName)
            .HasComputedColumnSql("[FirstName] + ' ' + [MiddleName] + ' ' + [LastName]");

        builder.Property(x => x.Email);

        builder.Property(x => x.Mobile);

        builder.Property(x => x.Password);

        builder.Property(x => x.IsActive);

    }

   
}
