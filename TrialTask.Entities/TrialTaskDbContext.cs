using Microsoft.EntityFrameworkCore;
using TrialTask.Entities.Tables;

namespace TrialTask.Entities
{
    public class TrialTaskDbContext : DbContext
    {
        public TrialTaskDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizAnswers> QuizAnswers { get; set; }

        public DbSet<QuizQuestions> QuizQuestions { get; set; }

        public DbSet<QuizResult> QuizResults { get; set; }

        public DbSet<QuizStatus> QuizStatuses { get; set; }


    }
}
