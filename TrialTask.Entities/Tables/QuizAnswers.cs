using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace TrialTask.Entities.Tables
{
    public class QuizAnswers
    {
        public QuizAnswers()
        {
            QuizQuestions = new HashSet<QuizQuestions>();
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("QuestionId")]
        public int QuestionId { get; set; }
        public string? Answer { get; set; }
        public bool IsRight { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<QuizQuestions> QuizQuestions { get; set; }
    }
}
