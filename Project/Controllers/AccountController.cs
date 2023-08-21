using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        ExamContext context;
        public AccountController()
        {
            context = new ExamContext();
        }
        [HttpGet]
        public IActionResult Register()
        {
            ValidStd valid  = new ValidStd();
            //valid.instructors = new SelectList(context.Instructors, "ID", "Name");
            

            return View("Adds",valid);
        }
        [HttpPost]
        public IActionResult Register (ValidStd valid)
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
                return RedirectToAction("Index", "Home");
            }
            else
            {
                valid.instructors = new SelectList(context.Instructors.ToList(), "ID", "Name");
                return View("Adds",valid);
            }
        }
        //================================================================
        //===============================================================
        //================================================================
        [HttpGet]
        public IActionResult RegisterAs()
        {
            //ValidStd valid = new ValidStd();
            //valid.instructors = new SelectList(context.Instructors, "ID", "Name");
            Valid valid = new Valid();


            return View("Addv", valid);
        }
        [HttpPost]
        public IActionResult RegisterAs(Valid valid)
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
                    Course=valid.Course



                };
                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
               
                return View("Addv", valid);
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVm log)
        {
            if (ModelState.IsValid)
            {
                if (log.AsInstructor)
                {
                    //ooo
                    Instructor instructor=context.Instructors.FirstOrDefault(s=>s.Email==log.Email && s.Password==log.Password);
                    if (instructor==null)
                    {
                        ModelState.AddModelError("", "Wrong Email or password");
                        return View(log);

                    }
                    HttpContext.Session.SetInt32("UserID", instructor.ID);
                    HttpContext.Session.SetString("UserName", instructor.Name);
                    HttpContext.Session.SetString("UserType", "Instructor");
                    return RedirectToAction("Index", "Home");

                }

                else
                {
                    Student student=context.Students.FirstOrDefault(s=>s.Email== log.Email && s.Password==log.Password);
                    if (student == null)
                    {
                        ModelState.AddModelError("", "Wrong Email or password");
                        return View(log);
                    }
                    //saving data
                    HttpContext.Session.SetInt32("UserID", student.ID);
                    HttpContext.Session.SetString("UserName", student.Name);
                    HttpContext.Session.SetString("UserType", "Student");
                }
                return RedirectToAction("Index", "Home");

            }
            return View(log);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }
    }
}
