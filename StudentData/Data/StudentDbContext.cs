using Microsoft.EntityFrameworkCore;
using StudentData.Models;

namespace StudentData.Data;

public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Students", "public");
            entity.HasKey(x => x.StudentID).HasName("PK_Students");

            entity.Property(x => x.StudentID)
                .ValueGeneratedOnAdd();
            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(x => x.Age)
                .IsRequired();
            entity.Property(x => x.Branch)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(x => x.DeletedAtUtc);
            entity.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
        });

        base.OnModelCreating(modelBuilder);
    }
}
