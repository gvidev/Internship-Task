using System.ComponentModel;

namespace Internship_Task.ViewModels.Task
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Assignee Id")]
        public int AssigneeId { get; set; }

        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }
    }
}
