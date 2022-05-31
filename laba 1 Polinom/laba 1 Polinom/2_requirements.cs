using Math = System.Math;
using static Algorithms.First_req;

namespace Algorithms
{
    public class Second_req
    {
        [STAThread]
        public static void Logic()
        {
            (double x, double y)[] data = { (0.91, 2.20230), (1.2, 2.53968), (2.3, 2.10793), (3.5, 0.70414), (4.7, 0.36791), (5.1, 0.39621), (6.8, 1.63904), (7.1, 2.07294), (7.7, 2.68631), (9, 1.51001) };

            IList<double> FxFormula = new List<double>();
            IList<double> FxGlobal = new List<double>();
            IList<double> FxCubic = new List<double>();
            for (double i = 1; i < 9; i += 0.1)
            {
                FxFormula.Add(Math.Exp(Math.Sin(i)));
                FxGlobal.Add(Polinom(data, i));
                // Cube interpolation
                FxCubic.Add(Polinom(data, i, 3));
            }

            Console.WriteLine("Formula:");
            Display(FxFormula);

            Console.WriteLine("Global:");
            Display(FxGlobal);

            Console.WriteLine("Cube:");
            Display(FxCubic);


            //Application.Run(new Chart() { PointsLists = new IList<double>[] { FxFormula, FxGlobal, FxCubic }, RowsNames = new string[] { "Формула", "Глобальна", "Кубічна" } });
        }
    }
}
