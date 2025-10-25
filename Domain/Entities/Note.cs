using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Notes")]
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteID { get; set; }

        // Foreign key to Subject
        public int? SubjectID { get; set; }

        [ForeignKey(nameof(SubjectID))]
        public Subject? Subject { get; set; }

        [Required]
        [MaxLength(100)]
        public string NoteTitle { get; set; } = string.Empty;

        public string? NoteContent { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
