using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialTask.Entities.Tables
{
    public class Quiz
    {
        public Quiz()
        {
            QuizQuestions = new HashSet<QuizQuestions>();
        }
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        [ForeignKey("QuizStatusId")]
        public int QuizStatusId { get; set; }
        public bool Active { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual ICollection<QuizQuestions> QuizQuestions { get; set; }

    }
}
