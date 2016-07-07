using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftQuiz.Models
{
    public class QuizQuestion
    {
        public QuizQuestion()
        {
            _suggestedAnswers = new List<AnswerSuggestion>();
        }

        private List<AnswerSuggestion> _suggestedAnswers;

        [JsonProperty("question")]
        public string Question { get; set; }

        public IEnumerable<AnswerSuggestion> answerSuggestions
        {
            get
            {
                return _suggestedAnswers;
            }
            set
            {
                _suggestedAnswers = value.ToList();
            }
        }

    }
}