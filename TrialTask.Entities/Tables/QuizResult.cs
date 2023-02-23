using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialTask.Entities.Tables
{
    public class QuizResult
    {
        [Key]
        public int Id { get; set; }

        public string? RollNumber { get; set; } // Student Quiz Roll Number to see result 

        [ForeignKey("QuizId")]
        public int QuizId { get; set; }

        [ForeignKey("QuestionId")]
        public int QuestionId { get; set; }

        [ForeignKey("AnswerId")]
        public int AnswerId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
