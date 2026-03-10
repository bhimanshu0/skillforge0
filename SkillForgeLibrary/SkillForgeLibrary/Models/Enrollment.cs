using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillForgeLibrary.Models;
[Table("Enrollment")]
public class Enrollment
{  [Key]
   [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int EnrollmentID { get; set; }
    [ForeignKey("CourseIdNavigation")]
    public int CourseID { get; set; }
    [ForeignKey("EmployeeIdNavigation")]
    public int EmployeeID { get; set; }
    [Required]
    public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    [Column(TypeName = "VARCHAR(20)")]
    public string? Status { get; set; } //Enrolled,inprogress,completed,certified

  //  public virtual Course CourseIdNavigation { get; set; } = null!;
   // public virtual User EmployeeIdNavigation { get; set; } = null!;

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}





