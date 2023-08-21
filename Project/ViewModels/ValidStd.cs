using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class ValidStd
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be from 2 to 50 char")]
        public string Name { get; set; }
        public int Instructor_ID { get; set; }
        [Range(18, 60, ErrorMessage = "Age must be from 18 to 60")]
        public int Age { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "You must give a valid email")]
        [EmailAddress()]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$", ErrorMessage = "You must match regex At least one digit [0-9]\r\nAt least one lowercase character [a-z]\r\nAt least one uppercase character [A-Z] At least 8 characters in length, but no more than 32.")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$", ErrorMessage = "You must match regex At least one digit [0-9]\r\nAt least one lowercase character [a-z]\r\nAt least one uppercase character [A-Z] At least 8 characters in length, but no more than 32.")]
        [Compare("Password", ErrorMessage = "Password must match confirm password")]
        public string ConfirmPassword { get; set; }
        [ValidateNever]
        public SelectList instructors { get; set; }
    }
}
