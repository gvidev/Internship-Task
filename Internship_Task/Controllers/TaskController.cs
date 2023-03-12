using Internship_Task.Entities;
using Internship_Task.Repositories;
using Internship_Task.ViewModels.Task;
using Microsoft.AspNetCore.Mvc;
namespace Internship_Task.Controllers
{
    public class TaskController:Controller
    {
        [HttpGet]
        public IActionResult Index(IndexVM model)
        {

            InternshipTaskDbContext context = new InternshipTaskDbContext();

            model.Items = context.Tasks.ToList();

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
            Entities.Task item = new Entities.Task();


            if (context.Employees.Where(m => m.Id == model.AssigneeId).FirstOrDefault() == null)
            {
                return View(model);
            }

            item.Title = model.Title;
            item.Description = model.Description;

            

            item.AssigneeId = model.AssigneeId;
            item.DueDate = model.DueDate;
            

            context.Tasks.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            EditVM model = new EditVM();
            InternshipTaskDbContext context = new InternshipTaskDbContext();
            Entities.Task item = new Entities.Task();

            item = context.Tasks.Where(m => m.Id == id).FirstOrDefault();

            if (item == null)
            {
                return RedirectToAction("Index", "Task");
            }

            model.Title = item.Title;
            model.Description = item.Description;
            model.AssigneeId = item.AssigneeId;
            model.DueDate = item.DueDate;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(EditVM model)
        {
            InternshipTaskDbContext context = new InternshipTaskDbContext();
            Entities.Task item = new Entities.Task();

            item = context.Tasks.Where(m => m.Id == model.Id).FirstOrDefault();

            item.Title = model.Title;
            item.Description = model.Description;
            item.AssigneeId = model.AssigneeId;
            item.DueDate = model.DueDate;

            context.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            InternshipTaskDbContext context = new InternshipTaskDbContext();
            Entities.Task item = new Entities.Task();

            item = context.Tasks.Where(m => m.Id == id).FirstOrDefault();

            if (item == null)
            {
                return RedirectToAction("Index", "Task");
            }

            context.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Task");
        }



    }
}
