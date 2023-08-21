using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Instructor:Person
    {
        [Required(ErrorMessage = "*")]
        
        public string Course { get; set; }
      
        //Navigation
       
      
        public List<Question> Questions { get; set; }
      
        public List<Exam> Exams { get; set; }
      

    }
}
