using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Internship_Task.ViewModels.Task
{
    public class CreateVM
    {

        [DisplayName("Title")]
        [Required(ErrorMessage = "This field is required!")]
        public string Title { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "This field is required!")]
        public string Description { get; set; }

        [DisplayName("Assignee Id")]
        [Required(ErrorMessage = "This field is required!")]
        public int AssigneeId { get; set; }

        [DisplayName("Due Date")]
        [Required(ErrorMessage = "This field is required!")]
        public DateTime DueDate { get; set; }


    }
}
