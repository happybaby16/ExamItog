using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            CriticalWay answer = new CriticalWay("In.txt", "Out.csv");
            answer.ReadFile();
            foreach (Points start in answer.ribs.Where(x => x.out_point == 1))
            {

                answer.FindHardWay(answer.ribs, start);

            }
            Console.WriteLine(answer.s);
            answer.Parse();
            answer.WriteFile();
        }
    }
}
