using Math = System.Math;

namespace Algorithms
{
    public class First_req
    {
        public static double Polinom((double x, double y)[] XnYorigin, double x, int n = 0)
        {
            double res = 0;
            (double x, double y)[] XnY;

            // Global interpolation
            if (n == 0)
            {
                n = XnYorigin.Length - 1;
                XnY = XnYorigin;
            }

            // interpolation of a given degree - search for the nearest points
            else
            {
                IList<double> diffSums = new List<double>();
                XnY = new (double x, double y)[n + 1];
                for (int i = 0; i < n + 1; i++)
                {
                    XnY[i] = XnYorigin[i];
                }
                {
                    double diffSum = 0;
                    for (int j = 0; j < n + 1; j++)
                    {
                        // Abs Returns the absolute value of a double-precision floating-point number.
                        diffSum += Math.Abs(XnYorigin[j].x - x);
                    }
                    diffSums.Add(diffSum);
                }
                for (int i = 1; i < XnYorigin.Length - n; i++)
                {
                    double diffSum = 0;
                    for (int j = 0; j < n + 1; j++)
                    {
                        diffSum += Math.Abs(XnYorigin[i + j].x - x);
                    }
                    diffSums.Add(diffSum);
                    if (diffSums[i] < diffSums[i - 1])
                    {
                        for (int j = 0; j < n + 1; j++)
                        {
                            XnY[j] = XnYorigin[i + j];
                        }
                    }
                    else
                        break;
                }
            }

            // Polinom counting
            for (int i = 0; i < n + 1; i++)
            {
                double xs = 1;
                for (int j = 0; j < n + 1; j++)
                {
                    if (i != j) xs *= (x - XnY[j].x) / (XnY[i].x - XnY[j].x);
                }
                res += XnY[i].y * xs;
            }

            //Console.WriteLine("Used points: " + string.Join(" | ", XnY));

            return res;
        }

        public static void Logic()
        {
            (double x, double y)[] data = { (0.91, 2.20230), (1.2, 2.53968), (2.3, 2.10793), (3.5, 0.70414), (4.7, 0.36791), (5.1, 0.39621), (6.8, 1.63904), (7.1, 2.07294), (7.7, 2.68631), (9, 1.51001) };
            //(double x, double y)[] data = { (0, 1), (2, 3), (3, 2), (5, 5) };

            Console.Write("Enter x: ");
            string x_input = Console.ReadLine();
            double x;
            while (!double.TryParse(x_input, out x))
            {
                Console.Write("This is not valid input. Enter valid x: ");
                x_input = Console.ReadLine();
            }

            Console.Write("Enter n (0 for global): ");
            string n_input = Console.ReadLine();
            int n;
            while (!int.TryParse(n_input, out n))
            {
                Console.Write("This is not valid input. Enter valid n: ");
                n_input = Console.ReadLine();
            }

            Console.WriteLine("Result: " + Polinom(data, x, n));
        }
        public static void Display(IList<double> name)
        {
            foreach (double value in name)
            {
                Console.WriteLine("\t" + value);
            }
        }
    }
}
