using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Person
    {
        public int ID { get; set; }
       
        public string Name { get; set; }
       
        public int Age { get; set; }
      
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
        

    }
}
