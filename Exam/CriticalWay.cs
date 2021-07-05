using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class CriticalWay
    {

        public string pathIn { get; set; }
        public string pathOut { get; set; }


        public CriticalWay(string pathIn, string pathOut)
        {
            this.pathIn = pathIn;
            this.pathOut = pathOut;
        }

        
        public string s = ""; // Переменная, куда записываются результат прохождения по всем веткам

        public List<Points> ribs = new List<Points>();// Список из рёбер и их весов

        List<dynamic[]> ways_weight = new List<dynamic[]>();// Массив, в который записываются пути и их суммарный вес {{путь(string), вес(int)}, {путь, вес}}

        int end_point;// Конечная точка критического пути





        /// <summary>
        /// Метод прохода по всем веткам за счёт рекурсии. Ответ записывает в переменную "s".
        /// </summary>
        /// <param name="ribs">List<Points></Points></param>
        /// <param name="start_point">Points</param>
        /// <returns></returns>
        public int FindHardWay(List<Points> ribs, Points start_point)
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



            foreach (Points ob in ribs.Where(x => x.out_point == start_point.in_point))
            {
                s = s + start_point.out_point + " - " + start_point.in_point + "|" + start_point.weight + "\n";
                if (start_point.in_point == ob.out_point)
                {

                    weight = weight + ob.weight;
                    weight = weight + FindHardWay(ribs, ob);




                }

            }

            return weight;

        }









        /// <summary>
        /// Парсит данные, полученные после прохождения по всем путям
        /// </summary>
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







       /// <summary>
       /// Метод поиска критического пути, который возвращает индекс на котором находится критический путь
       /// </summary>
       /// <returns>int</returns>
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




        /// <summary>
        /// Метод чтения исходных данных из .csv файла
        /// </summary>
        public void ReadFile()
        {
            try
            {
                StreamReader sr = new StreamReader(pathIn);
                using (sr)
                {
                    while (sr.EndOfStream != true)
                    {
                        try
                        {

                            var a = sr.ReadLine().Split(';');
                            Points temp = new Points(Convert.ToInt32(a[0]), Convert.ToInt32(a[1]), Convert.ToInt32(a[2]));
                            ribs.Add(temp);
                        }
                        catch(Exception ex)
                        {
                            using (StreamWriter sw = new StreamWriter(pathOut, false, Encoding.UTF8))
                            {
                                sw.WriteLine("Ошибка: " + ex.Message);
                                sw.Close();
                                Process.GetCurrentProcess().Kill();

                            }
                        }
                    }
                }

                int max = ribs[0].in_point;
                foreach (Points a in ribs)
                {
                    if (max < a.in_point)
                    {
                        max = a.in_point;
                    }

                }
                end_point = max;
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(pathOut, false, Encoding.UTF8))
                {
                    sw.WriteLine("Ошибка: " + ex.Message);
                    sw.Close();
                    Process.GetCurrentProcess().Kill();

                }
                
            }
           
        }








        /// <summary>
        /// Метод записи ответа в .csv файл
        /// </summary>
        public void WriteFile()
        {
            StreamWriter sw = new StreamWriter(pathOut, false, Encoding.UTF8);
            sw.WriteLine(ways_weight[FindMax()][0] + ways_weight[FindMax()][1] + " - длина критического пути");
            sw.Close();
        }









    }
}
