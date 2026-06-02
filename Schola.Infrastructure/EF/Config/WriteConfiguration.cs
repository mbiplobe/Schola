using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Schola.Infrastructure.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(pl => pl.Id);

        builder
            .Property(u => u.Id)
            .HasConversion(id => id.Value, id => new EntityID(id));


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



        builder.Property(x => x.Email)
               .HasConversion(
                    email => email.Value,          // Save to DB
                    value => new Email(value))  // Read from DB
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(x => x.Mobile)
              .HasConversion(
                   mobile => mobile.Value,          // Save to DB
                   value => new Phone(value))  // Read from DB
              .HasMaxLength(11)
              .IsRequired();

        builder.Property(x => x.Password)
             .HasConversion(
                  password => password.Value,          // Save to DB
                  value => new Password(value))  // Read from DB
             .HasMaxLength(50)
             .IsRequired();
               
            
       
    }

    // public void Configure(EntityTypeBuilder<SampleEntityItem> builder)
    // {
    //     builder.Property<Guid>("Id");
    //     builder.Property(pi => pi.Name);
    //     builder.Property(pi => pi.Quantity);
    //     builder.Property(pi => pi.IsTaken);
    //     builder.ToTable("SampleEntityItems");
    // }
    // public void Configure(EntityTypeBuilder<UserReadModel> builder)
    // {
    //     builder.ToTable("Users");
    // }
}
