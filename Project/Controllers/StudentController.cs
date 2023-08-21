using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.ViewModels;
using System.Diagnostics;

namespace Project.Controllers
{
    public class StudentController : Controller
    {
        ExamContext context;
        public StudentController()
        {
            context = new ExamContext();
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserID") != null)
            {
                List<Student> student = context.Students.ToList();
                return View(student);
            }
            return Unauthorized();
        }
        [HttpGet]
        public IActionResult Add() 
        {
            List<Instructor> instructors = context.Instructors.ToList();
            ViewBag.Instructors = new SelectList(instructors, "ID", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();

           return RedirectToAction("Index");
        }
        public IActionResult Get ()
        {
            return View();
        }
       


        
        public IActionResult Delete(int id)
        {
            
            
                Student student = context.Students.SingleOrDefault(s => s.ID == id);
                context.Students.Remove(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            
        }

    }
}
