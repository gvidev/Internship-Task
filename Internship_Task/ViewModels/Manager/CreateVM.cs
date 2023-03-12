using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Internship_Task.ViewModels.Manager
{
    public class CreateVM
    {

        
        [DisplayName("Full Name")]
        [Required(ErrorMessage = "This field is required!")]
        public string FullName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "This field is required!")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "This field is required!")]
        public string PhoneNumber { get; set; }


        [DisplayName("Address")]
        [Required(ErrorMessage = "This field is required!")]
        public string Address { get; set; }


        [DisplayName("Department")]
        [Required(ErrorMessage = "This field is required!")]
        public string Department { get; set; }

        [DisplayName("Monthly Salary")]
        [Required(ErrorMessage = "This field is required!")]
        public decimal MonthlySalary { get; set; }

        [DisplayName("Date Of Start")]
        [Required(ErrorMessage = "This field is required!")]
        public DateTime DateOfStart { get; set; }


    }
}
