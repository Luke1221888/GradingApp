using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeYourDay
{
    public interface IDay
    {

        string Name { get; set; }

        string Surname { get; set; }

        void AddRating(float rating);

        bool CheckAnswer(string answer, out float result);

        Statistics GetStatistics();

        void Run();
    }
}
