using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialTask.Entities;
using TrialTask.Entities.Tables;
using TrialTask.Objects;

namespace TiralTask.Repository.Services
{
    public class QuizService : IQuiz
    {
        private readonly TrialTaskDbContext _db;

        public QuizService(TrialTaskDbContext db)
        {
            _db = db;
        }
        public async Task<ResponseObject> SaveQuiz(QuizObject QuizObject)
        {
            ResponseObject response = new ResponseObject();
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (QuizObject != null)
                    {
                        if (!string.IsNullOrEmpty(QuizObject.Title))
                        {
                            if (QuizObject.QuizQustionsObject != null && QuizObject.QuizQustionsObject.Count > 0)
                            {
                                var Quiz = new Quiz();
                                Quiz.Title = QuizObject.Title ?? "";
                                Quiz.Description = QuizObject.Description ?? "";
                                Quiz.Active = true;
                                Quiz.QuizStatusId = QuizObject.StatusId;
                                Quiz.CreatedBy = "Trial Task";
                                Quiz.CreatedDate = DateTime.Now;
                                 _db.Add<Quiz>(Quiz);
                                 _db.SaveChanges();
                                QuizObject.Id = Quiz.Id;
                                if (Quiz.Id > 0)
                                {
                                    foreach (var questions in QuizObject.QuizQustionsObject)
                                    {
                                        var Question = new QuizQuestions();
                                        Question.QuizId = Quiz.Id;
                                        questions.QuizId = Quiz.Id;
                                        Question.Question = questions.Question;
                                        Question.IsMandatory = questions.IsMandatory;
                                        Question.CreatedBy = "Trial Task";
                                        Question.CreatedDate = DateTime.Now;
                                         _db.Add<QuizQuestions>(Question);
                                         _db.SaveChanges();
                                       
                                        if (Question.Id > 0)
                                        {
                                            foreach (var answers in questions.QuizQuestionAnswerObject)
                                            {
                                                var Answer = new QuizAnswers();
                                                Answer.QuestionId = Question.Id;
                                                answers.QuestionId = Question.Id;
                                                Answer.Answer = answers.Answer;
                                                Answer.IsRight = answers.IsRight;
                                                Answer.CreatedBy = "Trial Task";
                                                Answer.CreatedDate = DateTime.Now;
                                                 _db.Add<QuizAnswers>(Answer);
                                                _db.SaveChanges();
                                            }
                                        }
                                    }
                                }
                                transaction.Commit();
                                response.Success = true;
                                response.Data = QuizObject;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    response.Success = false;
                    response.Error = ex.Message.ToString();
                }
            }
            return response;
        }
        public async Task<ResponseObject> GetQuizData(int QuizId)
        {
            ResponseObject response = new ResponseObject();

            try
            {
                if (QuizId > 0)
                {
                    response.Data = _db.Quizzes.Include(x => x.QuizQuestions)
                          .ThenInclude(x => x.QuizAnswers)
                          //.Where(x=>x.Id==QuizId && x.Active == true)
                          .ToList();

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
