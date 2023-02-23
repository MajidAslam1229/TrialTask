using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialTask.Objects;

namespace TiralTask.Repository.Services
{
    public interface IQuizResult
    {
        public Task<ResponseObject> SaveQuizResult(List<QuizResultViewObject> quizResultViewObjects);
    }
}
