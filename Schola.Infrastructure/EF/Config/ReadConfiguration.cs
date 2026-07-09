using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schola.Infrastructure.EF.Models;

internal sealed class UserReadConfiguration : IEntityTypeConfiguration<UserReadModel>, 
IEntityTypeConfiguration<ClassReadModel>, 
IEntityTypeConfiguration<SectionReadModel>
{
    public void Configure(EntityTypeBuilder<UserReadModel> builder)
    {
        builder.ToTable("UserView");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.FirstName)
        .HasColumnName("First_Name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasColumnName("Middle_Name")
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .HasColumnName("Last_Name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Mobile)
            .HasColumnName("Mobile")
            .HasMaxLength(15)
            .IsRequired();
        builder.Property(x => x.Password);

        builder.Property(x => x.IsActive)
            .HasColumnName("Is_Active")
            .IsRequired();

    }

    public void Configure(EntityTypeBuilder<ClassReadModel> builder)
    {
        builder.ToTable("Classes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
        .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
        .HasColumnName("Description")
            .HasMaxLength(500)
            .IsRequired();
    }

    public void Configure(EntityTypeBuilder<SectionReadModel> builder)
    {
        builder.ToTable("sectionview");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasMaxLength(500)
            .IsRequired();

         builder.Property(x => x.Description)
            .HasColumnName("Description")
            .HasMaxLength(500)
            .IsRequired();
    }
}
