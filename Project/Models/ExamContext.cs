using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class ExamContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(" Server=DESKTOP-2MO8HKE\\OM;Database=Examination;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        //public DbSet<StudentQuestion> StudentQuestions { get; set; }
        //public DbSet<StudentExam> StudentExams { get; set;}
        public DbSet<Option> Options { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>()
            //    .HasOne(s => s.Instructor)
            //    .WithMany(i => i.Students)
            //    .HasForeignKey(s => s.Instructor_ID)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Instructor)
                .WithMany(i => i.Exams)
               .HasForeignKey(e => e.Instructor_ID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Instructor)
                .WithMany(i => i.Questions)
                .HasForeignKey(q => q.Instructor_ID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Option>()
                .HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(o => o.Question_ID);

        }
    }
   
}
