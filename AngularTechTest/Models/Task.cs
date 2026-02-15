using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularTechTest.Models
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("TaskName")]
        public string TaskName { get; set; }
    }
}