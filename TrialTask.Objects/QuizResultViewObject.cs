using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialTask.Objects
{
    public class QuizResultViewObject
    {
        public int Id { get; set; }
        public string RollNumber { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
