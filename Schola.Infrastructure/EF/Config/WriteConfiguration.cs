using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Schola.Infrastructure.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        // EntityID conversion
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new EntityID(value));

        // =========================
        // NAME (Owned Value Object)
        // =========================
        builder.OwnsOne(x => x.Name, name =>
        {
            name.Property(x => x.FirstName)
                .HasColumnName("First_Name")
                .HasMaxLength(100)
                .IsRequired();

            name.Property(x => x.MiddleName)
                .HasColumnName("Middle_Name")
                .HasMaxLength(100);

            name.Property(x => x.LastName)
                .HasColumnName("Last_Name")
                .HasMaxLength(100)
                .IsRequired();
        });

        // =========================
        // EMAIL (Value Object)
        // =========================
        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(x => x.Value)
                .HasColumnName("Email")
                .HasMaxLength(150)
                .IsRequired();
        });

        // =========================
        // MOBILE (Value Object)
        // =========================
        builder.OwnsOne(x => x.Mobile, mobile =>
        {
            mobile.Property(x => x.Value)
                .HasColumnName("Mobile")
                .HasMaxLength(11)
                .IsRequired();
        });

        // =========================
        // PASSWORD (Value Object)
        // =========================
        builder.OwnsOne(x => x.Password, password =>
        {
            password.Property(x => x.Value)
                .HasColumnName("Password")
                .HasMaxLength(50)
                .IsRequired();
        });
    }
}