using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Exam
    {
        internal object ExamQuestion;

        public int ID { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime ExamDate { get; set; }
        [Display (Name = "Course")]
        [ForeignKey("Instructor")]
        public int Instructor_ID { get; set; }
        //NAvigation
        public Instructor Instructor { get; set; }
        public List<Question> Questions { get; set; }
        public List<Student> Student { get; set; }
    }
}
