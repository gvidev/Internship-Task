using System.ComponentModel.DataAnnotations;

namespace Internship_Task.Entities
{
    public class Manager
    {

        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public decimal MonthlySalary { get; set; }
        public DateTime DateOfStart { get; set; }

    }
}
