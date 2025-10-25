using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Subjects")] // explicitly define table name for clarity
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectID { get; set; }  // simpler and consistent naming

        [Required]
        [MaxLength(100)]
        public string SubjectName { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Represents progress percentage (0–100)
        public int Progress { get; set; }

        // Target study hours (can be nullable)
        public int? TargetHours { get; set; }
    }
}
