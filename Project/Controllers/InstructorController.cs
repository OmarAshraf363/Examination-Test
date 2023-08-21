using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers
{
    public class InstructorController : Controller
    {
        ExamContext context;
        public InstructorController()
        {
            context = new ExamContext();
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserID") != null)
            {
                List<Instructor> instructor = context.Instructors.ToList();
                return View(instructor);
            }
            return Unauthorized();
        }
        [HttpGet]
        public IActionResult Add()
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Instructor instructor)
        {
           


                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");
          
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Instructor instructor = context.Instructors.SingleOrDefault(i => i.ID == id);
            return View(instructor);


        }
        [HttpPost]

        public IActionResult Edit(Instructor instructor)
        {
            Instructor oldins = context.Instructors.SingleOrDefault(i => i.ID == instructor.ID);
            oldins.Name=instructor.Name;
            oldins.Age=instructor.Age;
            oldins.Email=instructor.Email;
            oldins.Password=instructor.Password;
            oldins.ConfirmPassword=instructor.ConfirmPassword;
            return View(instructor);


        }
        public IActionResult Delete(int id)
        {
            Instructor instructor=context.Instructors.SingleOrDefault(instructor=>instructor.ID == id);
            context.Instructors.Remove(instructor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
