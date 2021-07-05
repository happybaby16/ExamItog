using System;
using System.Linq;


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
            answer.Parse();
            Console.WriteLine(answer.s);
            answer.WriteFile();
            Console.ReadLine();
        }
    }
}
