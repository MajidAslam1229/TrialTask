using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialTask.Entities.Tables
{
    public class QuizQuestions
    {
        public QuizQuestions()
        {
            QuizAnswers = new HashSet<QuizAnswers>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("QuizId")]
        public int QuizId { get; set; }
        public string? Question { get; set; }
        public bool IsMandatory { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<QuizAnswers> QuizAnswers { get; set; }
    }
}
