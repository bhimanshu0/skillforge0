using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace SkillForgeLibrary.Models;

public class SkillForgeDB : DbContext
{
    public SkillForgeDB()
    {

    }
    public SkillForgeDB(DbContextOptions<SkillForgeDB> options) : base(options)
    {

    }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Module> Modules { get; set; }
    public virtual DbSet<User> Trainers { get; set; }
    public virtual DbSet<AuditLog> AuditLog { get; set; }
    public virtual DbSet<Assessment> Assessments {get;set;}
    public virtual DbSet<Certification> Certifications {get;set;}
    public virtual DbSet<Result> Results {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=LTIN718736\\SQLEXPRESS;Initial Catalog=SkillForgeDB;Integrated Security=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasOne(a => a.Course)
            .WithMany()
            .HasForeignKey(a => a.CourseID)
            .OnDelete(DeleteBehavior.Cascade);

            entity.ToTable(t => t.HasCheckConstraint("CK_Assessment_MaxScore", "[MaxScore] >= 0 AND [MaxScore] <= 100"));

            entity.Property(a => a.MaxScore).HasPrecision(4, 1);

            entity.ToTable(t => t.HasCheckConstraint("CK_Assessment_Type", "[Type] IN ('Quiz', 'Exam', 'Practical')"));

        });

        modelBuilder.Entity<Result>().HasKey(r => new { r.AssessmentID, r.EmployeeID });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.Property(r => r.Score).HasPrecision(4, 1);

            entity.HasOne(r => r.Assessment)
            .WithMany(a => a.Results)
            .HasForeignKey(r => r.AssessmentID)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.UserRoleEmployee)
            .WithMany(u => u.Results)
            .HasForeignKey(r => r.EmployeeID)
            .OnDelete(DeleteBehavior.Restrict);

            entity.ToTable(t => t.HasCheckConstraint("CK_Assessment_MaxScore", "[MaxScore] >= 0 AND [MaxScore] <= 100"));

            entity.ToTable(t => t.HasCheckConstraint("CK_Result_Status", "[Status] IN ('Pass', 'Fail')"));
        });

        modelBuilder.Entity<Certification> (entity =>
        {
            entity.ToTable(t=> t.HasCheckConstraint("CK_Certificate_Status", "[Status] IN ('Active', 'Revoked', 'Expired')"));

            entity.ToTable(t => t.HasCheckConstraint("CK_Certification_Dates", 
            "[ExpiryDate] IS NULL OR [ExpiryDate] > [IssueDate]"));

            entity.HasOne(c => c.UserRoleEmployee)
            .WithMany(c => c.Certifications)
            .HasForeignKey(e => e.EmployeeID);

            entity.HasOne(c=> c.Course)
            .WithMany(co => co.Certifications)
            .HasForeignKey(c=> c.CourseID);
        });


    }
}
