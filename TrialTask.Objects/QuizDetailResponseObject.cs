using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialTask.Objects
{
    public class QuizDetailResponseObject
    {
        public QuizDetailResponseObject()
        {
            QuizQustionsObject = new List<QuizQustionsObject>();
        }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? QuizStatus { get; set; }
        public List<QuizQustionsObject> QuizQustionsObject { get; set; }
    }
    
}
