using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Option
    {
        public int ID { get; set; }
        public string Text { get; set; }
        [ForeignKey("Question")]
        public int Question_ID { get; set; }
        //Navigation
        public Question Question { get; set; }
    }
}
