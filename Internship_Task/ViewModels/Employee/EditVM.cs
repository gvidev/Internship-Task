using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Internship_Task.ViewModels.Employee
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

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Monthly Salary")]
        public decimal MonthlySalary { get; set; }

        [DisplayName("Manager Id")]
        public int ManagerId { get; set; }


    }
}
