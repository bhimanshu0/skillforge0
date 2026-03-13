using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Skillforge.Domain
{
    [Table("Competency")]
    public class Competency
    {
        [Key]
        public int CompetencyID { get; set; }
        [Required]
        [Column(TypeName ="CHAR(10)")]
        public string Name { get; set; }
        [Column(TypeName ="CHAR(50)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName ="CHAR(15)")]
        public string Level { get; set; }
        public ICollection<SkillGap> ?SkillGaps { get; set; }
    }
}
