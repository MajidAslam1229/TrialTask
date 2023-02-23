using Microsoft.AspNetCore.Mvc;
using TiralTask.Repository.Services;
using TrialTask.Objects;

namespace TrialTask.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class QuizResultController : ControllerBase
    {
        private readonly IQuizResult _QuizResult;

        public QuizResultController(IQuizResult QuizResult)
        {
            _QuizResult = QuizResult;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<QuizResultViewObject> quizResultViewObject)
        {
            var result = await _QuizResult.SaveQuizResult(quizResultViewObject);
            return Ok(result);
        }
    }
}
