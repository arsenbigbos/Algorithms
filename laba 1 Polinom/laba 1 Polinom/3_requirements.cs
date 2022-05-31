using static System.Math;
using static Algorithms.First_req;

namespace Algorithms
{
    public class Third_req
    {
        [STAThread]
        public static void Logic()
        {
            (double x, double y)[] data = { (0.91, 2.20230), (1.2, 2.53968), (2.3, 2.10793), (3.5, 0.70414), (4.7, 0.36791),
                (5.1, 0.39621), (6.8, 1.63904), (7.1, 2.07294), (7.7, 2.68631), (9, 1.51001) };

            IList<double> FxFormula_I = new List<double>();
            IList<double> FxFormula_II = new List<double>();
            IList<double> FxNumerical_I = new List<double>();
            IList<double> FxNumerical_II = new List<double>();

            double h = 0.1; // step
            int n = 3; // degree interpolation
            for (double i = 1; i < 9; i += h)
            {
                FxFormula_I.Add(Exp(Sin(i)) * Cos(i));
                FxFormula_II.Add(Exp(Sin(i)) * (Pow(Cos(i), 2) - Sin(i)));

                FxNumerical_I.Add(
                    (Polinom(data, i + h, n) - Polinom(data, i - h, n))
                    / (2 * h)
                    );
                FxNumerical_II.Add(
                    (Polinom(data, i + h, n) + Polinom(data, i - h, n) - 2 * Polinom(data, i, n))
                    / Pow(h, 2)
                    );
            }

            Console.WriteLine("Formula I:");
            Display(FxFormula_I);

            Console.WriteLine("Formula II:");
            Display(FxFormula_II);
            
            Console.WriteLine("Polinom:");
            Display(FxNumerical_I);

            Console.WriteLine("Polinom Pow:");
            Display(FxNumerical_II);

        }
        
    }
}
