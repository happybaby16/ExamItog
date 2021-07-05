
namespace Exam
{
    /// <summary>
    /// Класс для создания рёбер дерева
    /// </summary>
    public class Points
    {
        /// <summary>
        /// Точка выхода
        /// </summary>
        public int out_point { get; set; }



        /// <summary>
        /// Точка входа
        /// </summary>
        public int in_point { get; set; }




        /// <summary>
        /// Вес ребра
        /// </summary>
        public int weight { get; set; }



        public Points(int out_p, int in_p, int w)
        {
            out_point = out_p;
            in_point = in_p;
            weight = w;
        }
    }
}
