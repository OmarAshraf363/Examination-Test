using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.ViewModels;


namespace Project.Controllers
{
    public class ExamController : Controller
    {
        ExamContext context;
        public ExamController()
        {
            context = new ExamContext();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserID") != null)
            {
                List<Exam> exam = context.Exams.ToList();
              return View(exam);
            }
            return Unauthorized();
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<Instructor> instructors = context.Instructors.ToList();
            ViewBag.Instructors = new SelectList(instructors, "ID", "Course");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Exam exam)
        {
            context.Exams.Add(exam);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult EnterExam(int id)
        {
            Exam exam = context.Exams.Include(e => e.Questions).FirstOrDefault(e=>e.ID==id);
            return View(exam); 
        }

        public IActionResult Result()
        {
            List<Exam> exam = context.Exams.ToList();
            return View(exam);
        }

        public IActionResult Attend(int id)
        {
            int dgree = 0;
            List<Question> questions = context.Questions.ToList();
            string[] arr = new string[questions.Count];
            for (int i = 0; i < questions.Count; i++)
            {
                arr[i] = questions[i].Answer;

                if (arr[i] == Request.Form["question-" + questions[i].ID])
                {
                    dgree++;
                }
            }

            // الحضور
            Student student = context.Students.SingleOrDefault(s => s.ID == id);

            if (student.IsAttend == null)
            {
                student.IsAttend = true;
                student.Dgree = dgree;
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return Content("sorry the user has only one submited");
        }
        public IActionResult Refreash(int id)
        {
            Student student = context.Students.SingleOrDefault(s => s.ID == id);

            if (student.IsAttend != null)
            {
                student.IsAttend = null;
                student.Dgree = null;
                context.SaveChanges();

                return RedirectToAction("Index", "Student");
            }

            return View();
        }
        public ActionResult RefreashAll()
        {
            List<Student> students = context.Students.ToList();

            foreach (Student student in students)
            {
                if (student.IsAttend != null)
                {
                    student.IsAttend = null;
                    student.Dgree = null;
                }
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }
    
    
        public IActionResult Delete(int id)
        {
            Exam exam = context.Exams.SingleOrDefault(x => x.ID == id);
            context.Exams.Remove(exam);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
