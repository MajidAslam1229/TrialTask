using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialTask.Objects
{
    public class QuizObject
    {
        public QuizObject()
        {
            QuizQustionsObject = new List<QuizQustionsObject>();
        }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int StatusId { get; set; }
        public List<QuizQustionsObject> QuizQustionsObject { get; set; }
    }
    public class QuizQustionsObject
    {
        public QuizQustionsObject()
        {
            QuizQuestionAnswerObject = new List<QuizQuestionAnswerObject>();
        }
        public int QuizId { get; set; }
        public string? Question { get; set; }
        public bool IsMandatory { get; set; }
        public List<QuizQuestionAnswerObject> QuizQuestionAnswerObject { get; set; }
    }
    public class QuizQuestionAnswerObject
    {
        public int QuestionId { get; set; }
        public string? Answer { get; set; }
        public bool IsRight { get; set; }
    }
}
