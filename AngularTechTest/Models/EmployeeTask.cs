using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularTechTest.Models
{
    [Table("EmployeeTasks")]
    public class EmployeeTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [ForeignKey("Task")]
        public int TaskId { get; set; }

       
        public virtual Employee Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}