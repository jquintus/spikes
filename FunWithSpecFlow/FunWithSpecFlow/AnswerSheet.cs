using System.Collections.Generic;
using System.Linq;

namespace FunWithSpecFlow
{
    public class AnswerSheet
    {
        private Dictionary<string, int> _answers;
        private string _question;

        public AnswerSheet(string question)
        {
            _question = question;
            _answers = new Dictionary<string, int>();
        }

        public string TopAnswer
        {
            get
            {
                return _answers.OrderByDescending(kvp => kvp.Value)
                               .Select(kvp => kvp.Key)
                               .FirstOrDefault();
            }
        }

        public void AddAnswer(string answer)
        {
            if (_answers.ContainsKey(answer))
            {
                _answers[answer]++;
            }
            else
            {
                _answers[answer] = 1;
            }
        }

        public int Count(string answer)
        {
            return _answers.ContainsKey(answer)
                ? _answers[answer]
                : 0;
        }
    }
}