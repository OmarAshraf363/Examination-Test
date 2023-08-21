using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers
{
    public class ValidStdController : Controller
    {
        ExamContext context;
        public ValidStdController()
        {
            context = new ExamContext();
        }
        [HttpGet]
        public IActionResult Adds()
        {
            ValidStd valid = new ValidStd()
            {
                instructors = new SelectList(context.Instructors.ToList(), "ID", "Course")
            };
            return View(valid);
        }
        [HttpPost]
        public IActionResult Adds(ValidStd valid)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student()
                {
                    Name = valid.Name,
                    //Instructor_ID = valid.Instructor_ID,
                    Age = valid.Age,
                    Email = valid.Email,
                    Password = valid.Password,
                    ConfirmPassword = valid.ConfirmPassword,
                   


                };
                context.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction("Index", "Student");
            }
            else
            {
                valid.instructors = new SelectList(context.Instructors.ToList(), "ID", "Name");
                return View(valid);
            }
        }

    }
}
