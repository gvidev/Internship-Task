using Internship_Task.Entities;
using Internship_Task.Repositories;
using Internship_Task.ViewModels.Manager;
using Microsoft.AspNetCore.Mvc;

namespace Internship_Task.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index(IndexVM model)
        {
            InternshipTaskDbContext context = new InternshipTaskDbContext();

            model.managers = context.Managers.ToList();

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
            Manager item = new Manager();

            

            item.FullName = model.FullName;
            item.Email = model.Email;
            item.PhoneNumber = model.PhoneNumber;
            item.Address = model.Address;
            item.MonthlySalary = model.MonthlySalary;
            item.Department = model.Department;
            item.DateOfStart = model.DateOfStart;

            context.Managers.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            EditVM model = new EditVM();
            InternshipTaskDbContext context = new InternshipTaskDbContext();
            Manager item = new Manager();

            item = context.Managers.Where(m => m.Id == id).FirstOrDefault();

            if (item == null)
            {
                return RedirectToAction("Index", "Manager");
            }

            model.FullName = item.FullName;
            model.Email = item.Email;
            model.PhoneNumber = item.PhoneNumber;
            model.Address = item.Address;
            model.MonthlySalary = item.MonthlySalary;
            model.Department = item.Department;
            model.DateOfStart = item.DateOfStart.Date;


            return View(model);
        }

        [HttpPost]
        public IActionResult Update(EditVM model)
        {
            InternshipTaskDbContext context = new InternshipTaskDbContext();
            Manager item = new Manager();

            item = context.Managers.Where(m => m.Id == model.Id).FirstOrDefault();

            item.FullName = model.FullName;
            item.Email = model.Email;
            item.PhoneNumber = model.PhoneNumber;
            item.Address = model.Address;
            item.MonthlySalary = model.MonthlySalary;
            item.Department = model.Department;
            item.DateOfStart = model.DateOfStart;

            context.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Manager");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            InternshipTaskDbContext context = new InternshipTaskDbContext();
            Manager item = new Manager();

            item = context.Managers.Where(m => m.Id == id).FirstOrDefault();

            if (item == null)
            {
                return RedirectToAction("Index", "Manager");
            }

            context.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Manager");
        }


    }
}
