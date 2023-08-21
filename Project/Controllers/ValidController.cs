using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers
{
    public class ValidController : Controller
    {
        ExamContext context;
        public ValidController()
        {
            context = new ExamContext();
        }
        [HttpGet]
        public IActionResult Addv()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addv(Valid valid)
        {
            if (ModelState.IsValid)
            {
                Instructor instructor = new Instructor()
                {
                    Name = valid.Name,
                    Age = valid.Age,
                    Email = valid.Email,
                    Password = valid.Password,
                    ConfirmPassword = valid.ConfirmPassword,
                    Course = valid.Course,

                };
                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("Index", "Instructor");
            }
            return View(valid);
        }

    }
}
