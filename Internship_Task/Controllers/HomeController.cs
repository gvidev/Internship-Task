using Internship_Task.Entities;
using Internship_Task.Repositories;
using Internship_Task.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace Internship_Task.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Top_5_Employees(ViewModels.Top_5_Employees.IndexVM model)
        {
            InternshipTaskDbContext context = new InternshipTaskDbContext();

            List<Entities.Task> allTasks = new List<Entities.Task>();
            List<Employee> allEmployees = new List<Employee>();

            List<Employee> best_5_Employees = new List<Employee>();

            var today = DateTime.Today;

            //get the first day of this month and this year
            var month = new DateTime(today.Year, today.Month, 1);

            //we simply need to get the past month
            //and will have the first day of the previous month
            var firstDay = month.AddMonths(-1);

            //for the lastDay we just need to subtract with -1 current month firstDay - 1
            //and we get the previous month last day
            var lastDay = month.AddDays(-1);

            Dictionary<int,int> employeeIdCountTasks = new Dictionary<int,int>();


            //we have all the tasks
            foreach(var item in context.Tasks)
            {
                allTasks.Add(item);
            }

            //and all the employees
            foreach (var item in context.Employees)
            {
                allEmployees.Add(item);
            }

            //here find the employees with tasks
            //that finished their task in the period(last month first day, last month last day) 
            //and then add them in the dictionary
            //with (key = employeeId) and (value = tasks count - of finished!)
            foreach(var employee in allEmployees)
            {
                int count = 0;
                foreach(var task in allTasks) { 
                    if( employee.Id == task.AssigneeId) {
                        if (task.DueDate <= lastDay && task.DueDate >= firstDay) {
                            count++;
                        }
                    }
                }

                if(count!=0)
                employeeIdCountTasks.Add(employee.Id, count);
            }

            //Order by descending with LINQ function OrderByDescending
            var ordered = employeeIdCountTasks.OrderByDescending(x => x.Value);


            //with this foreach i get only the first 5 employees
            int countTo_5 = 0;
            foreach (var item in ordered)
            {
                //int employeeId = allEmployees.Where(x => x.Id == key).First().Id;
                var employee = allEmployees.Where(x => x.Id == item.Key).First();
                best_5_Employees.Add(employee);
                countTo_5++;

                if (countTo_5 == 5)
                {
                    break;
                }
            }


            //test if everything works
            //foreach (var item in best_5_Employees)
            //{
            //    Console.WriteLine(item.FullName);
            //}


            //put the result on our model and return it to the view
            model.employees = best_5_Employees;

            return View(model);
        }


        //same as above 
        //needs refactoring
        public IActionResult Top_5_Managers(ViewModels.Top_5_Managers.IndexVM model)
        {
            InternshipTaskDbContext context = new InternshipTaskDbContext();

            List<Manager> allManagers = new List<Manager>();
            List<Employee> allEmployees = new List<Employee>();

            List<Manager> best_5_Managers = new List<Manager>();


            Dictionary<int, int> managerIdCountEmployee = new Dictionary<int, int>();


            //we have all the managers
            foreach (var item in context.Managers)
            {
                allManagers.Add(item);
            }

            //and all the employees
            foreach (var item in context.Employees)
            {
                allEmployees.Add(item);
            }

            //here find the employees with tasks
            //that finished their task in the period(last month first day, last month last day) 
            //and then add them in the dictionary
            //with (key = employeeId) and (value = tasks count - of finished!)
            foreach (var manager in allManagers)
            {
                int count = 0;
                foreach (var employee in allEmployees)
                {
                    if (employee.ManagerId == manager.Id)
                    {
                        count++;
                    }
                }

                if (count != 0)
                    managerIdCountEmployee.Add(manager.Id, count);
            }

            //Order by descending with LINQ function OrderByDescending
            var ordered = managerIdCountEmployee.OrderByDescending(x => x.Value);


            //with this foreach i get only the first 5 employees
            int countTo_5 = 0;
            foreach (var item in ordered)
            {
                //int employeeId = allEmployees.Where(x => x.Id == key).First().Id;
                var manager = allManagers.Where(x => x.Id == item.Key).First();
                best_5_Managers.Add(manager);
                countTo_5++;

                if (countTo_5 == 5)
                {
                    break;
                }
            }


            //put the result on our model and return it to the view
            model.managers = best_5_Managers;

            return View(model);
        }




    }
}