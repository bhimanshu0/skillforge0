using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
    public virtual DbSet<User> Trainers { get; set; }
    public virtual DbSet<AuditLog> AuditLog {get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=LTIN718736\\SQLEXPRESS;Initial Catalog=SkillForgeDB;Integrated Security=True;TrustServerCertificate=True");
    }
}
