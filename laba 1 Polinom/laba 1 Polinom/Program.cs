
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class Starter
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }
        static void Main()
        {
        repeat:

            Console.Write("Choose the task (1, 2, 3): ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    First_req.Logic();
                    break;
                case "2":
                    Second_req.Logic();
                    break;
                case "3":
                    Third_req.Logic();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }

            Console.Write("Repeat? (y/n): ");

            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("\n");
                goto repeat;
            }
        }
    }
}