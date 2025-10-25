using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Goals")]
    public class Goal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoalID { get; set; }

        [Required]
        [MaxLength(100)]
        public string GoalTitle { get; set; } = string.Empty;

        public string? GoalDescription { get; set; }

        // Store as string in SQLite but converted from DateOnly
        [Required]
        public DateTime TargetDate { get; set; }   // safer for SQLite than DateOnly

        public bool IsAchieved { get; set; } = false;
    }
}
