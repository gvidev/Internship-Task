using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Internship_Task.ViewModels.Manager
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }


        [DisplayName("Address")]
        public string Address { get; set; }


        [DisplayName("Department")]
        public string Department { get; set; }

        [DisplayName("Monthly Salary")]
        public decimal MonthlySalary { get; set; }

        [DisplayName("Date Of Start")]
        public DateTime DateOfStart { get; set; }


    }
}
