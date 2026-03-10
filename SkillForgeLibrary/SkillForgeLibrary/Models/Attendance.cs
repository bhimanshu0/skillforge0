using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SkillForgeLibrary.Models;
[Table("Attendance")]
[PrimaryKey("AttendanceID","EnrollmentID")]//composite primary key

public class Attendance
{    public int AttendanceID { get; set; }

    [ForeignKey("EnrollmentIdNavigation")]
    public int EnrollmentID { get; set; }
    [Required]
    [Column(TypeName = "DATE")]
    public DateTime AttendanceDate { get; set; }
    [Required]
    [Column(TypeName ="VARCHAR(20)")]
    public string? Status { get; set; } // "Present", "Absent"
    public virtual Enrollment? EnrollmentIdNavigation { get; set; }
    }






