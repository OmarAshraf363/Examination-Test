using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Security.Cryptography.Xml;

namespace Project.Controllers
{
    public class QuestionController : Controller
    {
        ExamContext context;
        public QuestionController()
        {
            context = new ExamContext();
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserID") != null)
            {
                List<Question> question = context.Questions.ToList();
                return View(question);
            }
            return Unauthorized();
        }
        public IActionResult Details(int id)
        {
            Question question = context.Questions.Include(i => i.Instructor).SingleOrDefault(i => i.ID == id);
           
          
            return View(question);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Instructor> instructors = context.Instructors.ToList();
            ViewBag.Instructors = new SelectList(instructors, "ID", "Name");
            List<Exam> exams = context.Exams.ToList();
            ViewBag.Exams = new SelectList(exams, "ID", "Title");

            return View();
        }
        [HttpPost]
        public IActionResult Add(Question question)
        {
            try
            {
                context.Questions.Add(question);
                context.SaveChanges();
                return RedirectToAction("Index");
            }catch (Exception ex) { return Content($"Something went wrong\n {ex}"); }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Question question = context.Questions.SingleOrDefault(x => x.ID == id);
            List<Instructor> instructors = context.Instructors.ToList();
            ViewBag.Instructors = new SelectList(instructors, "ID", "Name");
            List<Exam> exams = context.Exams.ToList();
            ViewBag.Exams = new SelectList(exams, "ID", "Title");



            return View(question);

        }
        [HttpPost]
        public IActionResult Edit(Question question)
        {
            Question oldquestion = context.Questions.SingleOrDefault(x => x.ID == question.ID);
            oldquestion.Head = question.Head;
            oldquestion.Body = question.Body;
            oldquestion.Answer = question.Answer;
            oldquestion.Instructor_ID=question.Instructor_ID;
            oldquestion.Exam_ID=question.Exam_ID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Question question=context.Questions.SingleOrDefault( x => x.ID == id);
            context.Questions.Remove(question);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
