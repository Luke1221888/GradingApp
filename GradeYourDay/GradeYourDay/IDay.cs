using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeYourDay
{
    public interface IDay
    {
        string Day { get; set; }

        void AddRating(float rating);

        void AddRating(string answer);

        bool CheckAnswer(string answer, out float result);

        Statistics GetStatistics();

        void ShowQuestions();

        delegate void TextAddedToFile(object sender, EventArgs args);

        event TextAddedToFile TextAdded;
    }
}
