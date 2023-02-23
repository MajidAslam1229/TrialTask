using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiralTask.Repository.Services;
using TrialTask.Objects;
using static Azure.Core.HttpHeader;

namespace TrialTask.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuiz _Quiz;

        public QuizController(IQuiz Quiz)
        {
            _Quiz = Quiz;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuizObject QuizObject)
        {
            var result = await _Quiz.SaveQuiz(QuizObject);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int QuizId)
        {
            var result = await _Quiz.GetQuizData(QuizId);
            return Ok(result);
        }
    }
}
