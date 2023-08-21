using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Student:Person
    {
        public bool? IsAttend { get; set; }
        public int? Dgree { get; set; }


        //NAvigation

        public List<Exam> Exams { get; set; }
        public List<Question> Questions { get; set; }
    }
}
