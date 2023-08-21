using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Head  { get; set; }
        public string Body { get; set; }
       
        public string Answer { get; set; }
        [ForeignKey("Instructor")]
        public int Instructor_ID { get; set; }
        [ForeignKey("Exam")]
        public int Exam_ID { get; set; }
        //NAvigation
        public Instructor Instructor {get; set; }
        public Exam Exam { get; set; }
        public List<Option> Options { get; set; }
       
        public List<Student> Students { get; set; }

    }
}
