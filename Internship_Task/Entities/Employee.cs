using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internship_Task.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal MonthlySalary { get; set; }
        public int ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public Manager Manager { get; set; }


    }
}
