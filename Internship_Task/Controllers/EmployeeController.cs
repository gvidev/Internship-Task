using Internship_Task.Entities;
using Internship_Task.Repositories;
using Internship_Task.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Internship_Task.Controllers
{
    public class EmployeeController:Controller
    {
        [HttpGet]
        public IActionResult Index(IndexVM model)
        {

            InternshipTaskDbContext context =  new InternshipTaskDbContext();

            model.Items = context.Employees.ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            InternshipTaskDbContext context = new InternshipTaskDbContext();
            Employee item = new Employee();

            if (context.Managers.Where(m => m.Id == model.ManagerId).FirstOrDefault() == null)
            {
                return View(model);
            }

            item.FullName = model.FullName;
            item.Email = model.Email;
            item.PhoneNumber = model.PhoneNumber;
            item.DateOfBirth = model.DateOfBirth;
            item.MonthlySalary = model.MonthlySalary;
            item.ManagerId = model.ManagerId;

            context.Employees.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            EditVM model = new EditVM();
            InternshipTaskDbContext context = new InternshipTaskDbContext();
            Employee item = new Employee();

            item = context.Employees.Where(m => m.Id == id).FirstOrDefault();

            if (item == null)
            {
                return RedirectToAction("Index", "Employee");
            }

            model.FullName = item.FullName;
            model.Email = item.Email;
            model.PhoneNumber = item.PhoneNumber;
            model.DateOfBirth = item.DateOfBirth;
            model.MonthlySalary = item.MonthlySalary;
            model.ManagerId = item.ManagerId;

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(EditVM model)
        {
            InternshipTaskDbContext context = new InternshipTaskDbContext();
            Employee item = new Employee();

            item = context.Employees.Where(m => m.Id == model.Id).FirstOrDefault();

            item.FullName = model.FullName;
            item.Email = model.Email;
            item.PhoneNumber = model.PhoneNumber;
            item.DateOfBirth = model.DateOfBirth;
            item.MonthlySalary = model.MonthlySalary;
            item.ManagerId  = model.ManagerId;

            context.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            InternshipTaskDbContext context = new InternshipTaskDbContext();
            Employee item = new Employee();

            item = context.Employees.Where(m => m.Id == id).FirstOrDefault();

            if (item == null)
            {
                return RedirectToAction("Index", "Employee");
            }

            context.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

    }
}
