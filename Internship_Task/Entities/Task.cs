using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internship_Task.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public int AssigneeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        [ForeignKey(nameof(AssigneeId))]
        public Employee Assignee { get; set; }




    }
}
