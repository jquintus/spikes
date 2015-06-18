using FunWithSpecFlow;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    [Binding]
    public class OrderingAnswersSteps
    {
        private AnswerSheet _sheet;

        [Given]
        public void Given_there_is_a_question_QUESTION_with_the_answers(string question, Table table)
        {
            _sheet = new AnswerSheet(question);

            foreach (var row in table.Rows)
            {
                string answer = row["Answer"];
                int count = Convert.ToInt32(row["Vote"]);

                for (int i = 0; i < count; i++)
                {
                    _sheet.AddAnswer(answer);
                }
            }
        }

        [Then]
        public void Then_the_answer_ANSWER_should_be_on_top(string answer)
        {
            Assert.AreEqual(answer, _sheet.TopAnswer);
        }

        [When]
        public void When_you_upvote_answer_ANSWER(string answer)
        {
            _sheet.AddAnswer(answer);
        }
    }
}