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
        public void Given_there_is_a_question_P0_with_the_answers(string p0, Table table)
        {
            _sheet = new AnswerSheet(p0);

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
        public void Then_the_answer_P0_should_be_on_top(string p0)
        {
            Assert.AreEqual(p0, _sheet.TopAnswer);
        }

        [When]
        public void When_you_upvote_answer_P0(string p0)
        {
            _sheet.AddAnswer(p0);
        }
    }
}