using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Skillforge.Domain;

[Table("Audit")]
public class Audit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuditID { get; set; }

    // Mapped as string because UserID in the User table is VARCHAR(20)
    [Required]
    [MaxLength(20)]
    public string HRID { get; set; }

    [MaxLength(50)]
    public string Scope { get; set; }

    // No max length applied to allow for detailed audit findings (similar to NVARCHAR(MAX))
    public string Findings { get; set; }

    public DateTime Date { get; set; }

    [MaxLength(20)]
    public string Status { get; set; }

    [ForeignKey("HRID")]
    public virtual User? HRUser { get; set; }
}
