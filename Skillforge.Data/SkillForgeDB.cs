using System;
using Microsoft.EntityFrameworkCore;
using Skillforge.Domain;

namespace SkillForgeLibrary.Models;

public class SkillForgeDB:DbContext
{
    public SkillForgeDB(){
        
    }
    public SkillForgeDB(DbContextOptions<SkillForgeDB> options): base(options)
    {
        
    }
    public virtual DbSet<Course> Courses{ get; set; }
    public virtual DbSet<Module> Modules { get; set; }
    public virtual DbSet<Result> Results {get;set;}
    public virtual DbSet<User> Trainers { get; set; }
    public virtual DbSet<AuditLog> AuditLogs {get; set; }
    public virtual DbSet<Attendance> Attendances {get;set;}
    public virtual DbSet<Competency> Competencies {get;set;}
    public virtual DbSet<Enrollment> Enrollments {get;set;}
    public virtual DbSet<Report> Reports {get;set;}
    public virtual DbSet<SkillGap> SkillGaps {get;set;}
    public virtual DbSet<Audit> Audits {get;set;}
    public virtual DbSet<Certification> Certifications {get;set;}
    public virtual DbSet<ComplianceRecord> ComplianceRecords {get;set;}
    public virtual DbSet<Assessment> Assessments {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=LTIN718269\\SQLEXPRESS; Initial Catalog=SfDb;Integrated Security=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 

        modelBuilder.Entity<ComplianceRecord>()
        .HasOne(cr => cr.Certification)
        .WithMany() 
        .HasForeignKey(cr => cr.CertificationID)
        .OnDelete(DeleteBehavior.NoAction);
    }
}
