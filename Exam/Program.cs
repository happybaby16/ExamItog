using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Hard> ribs = new List<Hard>();
            StreamReader sr = new StreamReader(@"data.csv");
            using (sr)
            {
                while (sr.EndOfStream != true)
                {
                    try
                    {

                        var a = sr.ReadLine().Split(';');
                        Hard temp = new Hard();
                        temp.AddData(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]), Convert.ToInt32(a[2]));
                        ribs.Add(temp);
                    }
                    catch
                    {
                        break;
                    }
                }
            }

            int max = ribs[0].in_point;
            foreach (Hard a in ribs)
            {
                if (max < a.in_point)
                {
                    max = a.in_point;
                }

            }


            int end_point = max;

            Hard answer = new Hard();
            foreach (Hard start in ribs.Where(x => x.out_point == 1))
            {

                answer.FindHardWay(ribs, start, end_point);

            }
            answer.Parse();
            answer.WriteFile("Крит.csv");
        }
    }
}
