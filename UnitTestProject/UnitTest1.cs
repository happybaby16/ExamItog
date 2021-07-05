using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exam;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        CriticalWay answer = new CriticalWay(@"C:\Users\pavel\Desktop\Экзамен\Exam\Exam\bin\Debug\In.txt", "Out.csv");
        [TestMethod]
        public void TestMethod()
        {
            answer.ReadFile();
            //Сравнение весов после чтение из файла
            Assert.AreEqual(answer.ribs[0].weight, 3);
            Assert.AreEqual(answer.ribs[1].weight, 7);

        }
        [TestMethod]
        public void TestMethod1()
        {
            answer.ReadFile();
            foreach (Points start in answer.ribs.Where(x => x.out_point == 1))
            {

                answer.FindHardWay(answer.ribs, start);

            }
            answer.Parse();
            Assert.AreEqual(answer.FindMax(), 2); // Максимальный критический путь имеет индекс 2

        }
    }
}
