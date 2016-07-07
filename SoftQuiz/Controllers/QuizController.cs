using Newtonsoft.Json;
using SoftQuiz.Extensions;
using SoftQuiz.Models;
using SoftQuiz.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SoftQuiz.Controllers
{
    public class QuizController : ApiController
    {
        // GET: api/Quiz/scrum
        [HttpGet]
        [Route("api/Quiz/{quizName}")]
        public HttpResponseMessage Get(string quizName)
        {
            string jsonFile = QuizDataService.GetQuizData(this.GetApplicationRootPath(), quizName);

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonFile, Encoding.UTF8, "application/json");
            return response;
        }

        // POST: api/Quiz
        [HttpPost]
        public HttpResponseMessage Post([FromBody] QuizResult data)
        {
            // Do somthing with the posted data - i.e. log the result to db or ....

            int correctAnswers = 0;

            foreach (QuizAnswer qa in data.Answers)
            {
                if (qa.IsCorrect) correctAnswers++;
            }

            string resultString = string.Format("Du hade {0} rätt svar på {1} frågor.", correctAnswers, data.Answers.Count());
            string jsonData = JsonConvert.SerializeObject(resultString);

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            return response;
        }


        /// <summary>
        /// Used to capture the raw json data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Quiz/PostRawBufferManual")]
        public async Task<string> PostRawBufferManual()
        {
            string result = await Request.Content.ReadAsStringAsync();
            return result;
        }
    }
}
