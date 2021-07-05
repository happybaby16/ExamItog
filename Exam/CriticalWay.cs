using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class CriticalWay
    {
        public string s = "";
        List<dynamic[]> ways_weight = new List<dynamic[]>();

        public int out_point { get; set; }
        public int in_point { get; set; }
        public int weight { get; set; }

        public void AddData(int out_p, int in_p, int w)
        {
            out_point = out_p;
            in_point = in_p;
            weight = w;
        }

        public int FindHardWay(List<CriticalWay> ribs, CriticalWay start_point, int end_point)
        {



            int weight = 0;
            if (start_point.out_point == 1)
            {

                weight = start_point.weight;
            }


            if (start_point.in_point == end_point)
            {
                s = s + start_point.out_point + " - " + start_point.in_point + "|" + start_point.weight + ";";
                return weight;
            }



            foreach (CriticalWay ob in ribs.Where(x => x.out_point == start_point.in_point))
            {
                s = s + start_point.out_point + " - " + start_point.in_point + "|" + start_point.weight + "\n";
                if (start_point.in_point == ob.out_point)
                {

                    weight = weight + ob.weight;
                    weight = weight + FindHardWay(ribs, ob, end_point);




                }

            }

            return weight;

        }




        public void Parse()
        {
            string[] ways = s.Split(';');
            for (int i = 0; i < ways.Length - 1; i++)
            {
                var a = ways[i].Split('\n');
                string way = "";
                int weight = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    try
                    {
                        var data = a[j].Split('|');
                        weight = weight + Convert.ToInt32(data[1]);
                        way = way + data[0] + ";" + "\n";
                    }
                    catch
                    {
                        break;
                    }



                }



                ways_weight.Add(new dynamic[2]);
                ways_weight[i][0] = way;
                ways_weight[i][1] = weight;
            }

        }



        public int FindMax()
        {
            int max = ways_weight[0][1], index = 0;
            for (int i = 0; i < ways_weight.Count; i++)
            {
                if (max < ways_weight[i][1])
                {
                    max = ways_weight[i][1];
                    index = i;
                }
            }
            return index;
        }


        public void WriteFile(string path)
        {
            StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
            sw.WriteLine(ways_weight[FindMax()][0] + ways_weight[FindMax()][1] + " - длина критического пути");
            sw.Close();
        }









    }
}
