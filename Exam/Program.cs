using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            Trace.Listeners.Add(new TextWriterTraceListener(new StreamWriter("log.txt", true)));
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;


            CriticalWay answer = new CriticalWay("In.csv", "Out.csv");
            answer.ReadFile();
            foreach (Points start in answer.ribs.Where(x => x.out_point == 1))
            {

                answer.FindHardWay(answer.ribs, start);

            }
            answer.Parse();
            answer.WriteFile();
        }
    }
}
