using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialTask.Objects;

namespace TiralTask.Repository.Services
{
    public interface IQuiz
    {
        public Task<ResponseObject> SaveQuiz(QuizObject QuizObject);
        public Task<ResponseObject> GetQuizData(int QuizId);
    }
}
