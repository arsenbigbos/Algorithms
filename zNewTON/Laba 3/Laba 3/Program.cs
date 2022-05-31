using System;
using static System.Math;
using System.Collections.Generic;

namespace Algorithms
{
    public class Laba3
    {
        public static double Newton(double x0, double error)
        {
            double Fx(double x)
            {
                // return Pow(x, 2) - Sin(5 * x);
                return 2*x - Math.Log(10, x) - 4;
            }
            IList<double> xs = new List<double>();
            xs.Add(x0);
            int k = 0;
            while (true)
            {
                k++;
                double x_prev = xs[k - 1];
                double x = x_prev - Fx(x_prev) /
                           (2 * x_prev - 5 * Cos(5 * x_prev));
                xs.Add(x);
                double error_ = Abs(xs[k] - xs[k - 1]);
                Console.WriteLine("| {0,1} | {1,8:0.00000} | {2,8:0.000000} |", k, x, error_);
                if (Fx(xs[k]) == 0) return xs[k];
                if (error_ < error) return xs[k];
            }
        }
        static void Main()
        {
            Console.WriteLine("| {0,-1} | {1,-8:0.00000} | {2,-8:0.000000} |", "K", "X", "ε");
            Newton(-0.4, Pow(10, -4));
            Console.WriteLine();
        }
    }
}