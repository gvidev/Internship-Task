using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Internship_Task.ViewModels.Employee
{
    public class CreateVM
    {

        [DisplayName("Full Name")]
        [Required(ErrorMessage ="This field is required!")]
        public string FullName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "This field is required!")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "This field is required!")]
        public string PhoneNumber { get; set; }

        [DisplayName("Date Of Birth")]
        [Required(ErrorMessage = "This field is required!")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Monthly Salary")]
        [Required(ErrorMessage = "This field is required!")]
        public decimal MonthlySalary { get; set; }

        [DisplayName("Manager Id")]
        [Required(ErrorMessage = "This field is required!")]
        public int ManagerId { get; set; }

    }
}
