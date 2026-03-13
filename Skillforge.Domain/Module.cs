using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skillforge.Domain;
[Table ("Module")]
public class Module
{
    [Key]
    [Column (TypeName ="char(5)")]
    public string ModuleID {get; set;}
    [Column (TypeName ="char(5)")]
    [ForeignKey("CourseIDNavigation")]
    public string CourseID {get; set;}
    [Column (TypeName ="char(20)")]
    public string Title {get; set;}
    [Column (TypeName ="char(50)")]
    public string ContentURI {get; set;}
    public int Duration {get; set;}
    [Column (TypeName ="char(10)")]
    public string Status {get; set;}

    public virtual Course? CourseIDNavigation {get; set;}

}
