

namespace Project.ViewModels
{
    public class ExamQuestions
    {
        public int Ex_ID { get; set; }
        public string Ex_Title { get; set; }
        public int score { get; set; }
        public List<Students> Students { get; set; } = new List<Students>();
    }
  public  class Students
    { 
        public int Std_ID { get; set; }
        public string std_Name { get; set;}
    
    
    }
}
