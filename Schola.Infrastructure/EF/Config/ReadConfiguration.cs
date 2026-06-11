using Schola.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Schola.Infrastructure.EF.Config;

internal sealed class ReadConfiguration :
IEntityTypeConfiguration<ClassReadModel>,
IEntityTypeConfiguration<UserReadModel>,
IEntityTypeConfiguration<StudentReadModel>,
IEntityTypeConfiguration<GuardianReadModel>,
IEntityTypeConfiguration<GuardianRelationshipReadModel>,
IEntityTypeConfiguration<StudentGuardianMapReadModel>
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

        builder.Property(x => x.IsActive)
        .HasColumnName("Is_Active")
        .IsRequired()
        ;

        // builder.Property(x => x.IsActive);

    }
    public void Configure(EntityTypeBuilder<StudentReadModel> builder)
    {
        builder.ToTable("students");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.StudentCode)
            .HasMaxLength(50)
            .IsRequired();


        builder.Property(x => x.RollNumber)
        .HasColumnName("Roll_Number")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.DateOfBirth)
            .HasColumnName("Date_Of_Birth")
            .IsRequired();

        builder.Property(x => x.GenderId)
            .HasColumnName("Gender_Id")
            .IsRequired();

        builder.Property(x => x.AdmissionDate)
            .HasColumnName("Admission_Date");

        builder.Property(x => x.BloodGroupId)
            .HasColumnName("Blood_Group_Id");

        builder.Property(x => x.CreatedDate)
           .HasColumnName("Created_Date")
           .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("Created_By")
            .IsRequired();

        builder.HasMany(x => x.StudentGuardians)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Cascade);


    }
    public void Configure(EntityTypeBuilder<GuardianReadModel> builder)
    {
        builder.ToTable("guardians");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.GuardianName)
            .HasColumnName("Guardian_Name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.GuardianPhone)
            .HasColumnName("Guardian_Phone")
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasMaxLength(150);

        builder.Property(x => x.CreatedDate)
          .HasColumnName("Created_Date")
          .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("Created_By")
            .IsRequired();
    }
    public void Configure(EntityTypeBuilder<GuardianRelationshipReadModel> builder)
    {
        builder.ToTable("guardian_relationships");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.RelationshipName)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.RelationshipName)
            .IsUnique();
    }
    public void Configure(EntityTypeBuilder<StudentGuardianMapReadModel> builder)
    {
        builder.ToTable("student_guardian_map");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.StudentId, x.GuardianId })
            .IsUnique();

        builder.HasOne(x => x.Student)
            .WithMany(x => x.StudentGuardians)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Guardian)
            .WithMany(x => x.StudentGuardians)
            .HasForeignKey(x => x.GuardianId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Relationship)
            .WithMany(x => x.StudentGuardians)
            .HasForeignKey(x => x.RelationshipId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public void Configure(EntityTypeBuilder<ClassReadModel> builder)
    {
        builder.ToTable("classes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("text");
            
        builder.Property(x => x.CreatedDate)
        .HasColumnName("created_date")
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

    builder.Property(x => x.CreatedBy)
        .HasColumnName("created_by")
        .HasMaxLength(50)
        .IsRequired();

    builder.Property(x => x.UpdatedDate)
        .HasColumnName("updated_date")
        .ValueGeneratedOnAddOrUpdate();

    builder.Property(x => x.UpdatedBy)
        .HasColumnName("updated_by")
        .HasMaxLength(50);
    }
}


       