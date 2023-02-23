using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiralTask.Repository.Services;
using TrialTask.Entities;
using TrialTask.Entities.Tables;
using TrialTask.Objects;

namespace TiralTask.Repository.Services
{
    public class QuizResultService : IQuizResult
    {
        private readonly TrialTaskDbContext _db;
        public QuizResultService(TrialTaskDbContext db)
        {
            _db = db;
        }

        public async Task<ResponseObject> SaveQuizResult(List<QuizResultViewObject> quizResultViewObjects)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                if (quizResultViewObjects != null)
                {
                    foreach(var quizresult in quizResultViewObjects)
                    {
                        var QuizResult = new QuizResult();
                        QuizResult.RollNumber = quizresult.RollNumber ?? "";
                        QuizResult.QuizId = quizresult.QuizId;
                        QuizResult.QuestionId = quizresult.QuestionId;
                        QuizResult.AnswerId = quizresult.AnswerId;
                        QuizResult.CreatedBy = "Trial Task";
                        QuizResult.CreatedDate = DateTime.Now;
                        _db.Add<QuizResult>(QuizResult);
                        _db.SaveChanges();
                        quizresult.Id = QuizResult.Id;
                    }
                    response.Data = quizResultViewObjects;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message.ToString();
            }
            return response;
        }

    }
}
