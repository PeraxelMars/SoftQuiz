using System.Collections.Generic;
using System.Linq;

namespace SoftQuiz.Models
{
    public class QuizResult
    {
        private List<QuizAnswer> _answers;
        public string Zip { get; set; }

        public IEnumerable<QuizAnswer> Answers
        {
            get
            {
                return _answers;
            }
            set
            {
                _answers = value.ToList();
            }
        }

        public QuizResult()
        {
            _answers = new List<QuizAnswer>();
        }
    }
}