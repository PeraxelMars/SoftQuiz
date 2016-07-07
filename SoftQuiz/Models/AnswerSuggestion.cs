using Newtonsoft.Json;

namespace SoftQuiz.Models
{
    public class AnswerSuggestion
    {
        [JsonProperty("answer")]
        public string Answer { get; set; }

        [JsonProperty("isCorrect")]
        public bool IsCorrect { get; set; }

        [JsonProperty("answeredThis")]
        public bool AnsweredThis { get; set; }
    }
}