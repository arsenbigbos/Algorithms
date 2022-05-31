using System;
using System.Collections.Generic;
using static System.Console;

namespace alg_lab7
{
    enum Graph
    {
        a,
        b,
        c,
        d,
        f,
        e
    }
    class Program
    {
        static int Graph(string value)
        {
            switch (value)
            {
                case "a":
                    return 0;
                case "b":
                    return 1;
                case "c":
                    return 2;
                case "d":
                    return 3;
                case "f":
                    return 4;
                case "e":
                    return 5;
                default:
                    Console.WriteLine("Not found vertex");
                    break;
            }
            return 0;
        }
        static void Floyd(int[,] mainGraph, int from, int to)
        {
            int numberVertex = mainGraph.GetLength(0);
            int[,] vertex = new int[numberVertex, numberVertex];
            int[,] graph = new int[numberVertex, numberVertex]; ;
            for (int i = 0; i < numberVertex; i++)
            {
                for (int j = 0; j < numberVertex; j++)
                {
                    graph[i, j] = mainGraph[i, j];
                }
            }
            for (int k = 0; k < numberVertex; k++)
            {
                for (int i = 0; i < numberVertex; i++)
                {
                    for (int j = 0; j < numberVertex; j++)
                    {
                        if (graph[i, k] + graph[k, j] < graph[i, j] && graph[i, k] !=
                       int.MaxValue && graph[k, j] != int.MaxValue)
                        {
                            graph[i, j] = graph[i, k] + graph[k, j];
                            vertex[i, j] = k;
                        }
                    }
                }
            }
            if (graph[from, to] != int.MaxValue)
            {
                Console.WriteLine($"The shortest way from {(Graph)from} to {(Graph)to}: {graph[from, to]} ");
                string shortWay = "";
                shortWay += (Graph)to;
                int value = to;
                while (value != 0)
                {
                    if (vertex[from, value] != 0)
                    {
                        shortWay += (Graph)vertex[from, value];
                        value = vertex[from, value];
                    }
                    else
                    {
                        shortWay += (Graph)from;
                        break;
                    }
                }
                for (int i = shortWay.Length - 1; i >= 0; i--)
                    Console.Write($"{shortWay[i]} ");
            }
            else
            {
                Console.WriteLine($"error: {(Graph)from} -> {(Graph)to} ");
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            //Graph
            int[,] graph = new int[6, 6] {
                {0, 3, 6, int.MaxValue, int.MaxValue, int.MaxValue},
                {int.MaxValue, 0, int.MaxValue, 2, int.MaxValue, int.MaxValue},
                {int.MaxValue, int.MaxValue, 0, int.MaxValue, 5, 0},
                {int.MaxValue, int.MaxValue, int.MaxValue, 0, 4, 5},
                {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 0, 7},
                {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 0}
                };
            Console.Write("Enter start point: ");
            int FromVertex = Graph(ReadLine()); // Number from
            Console.Write("Enter finish point: ");
            int ToVertex = Graph(ReadLine()); // Number in
            Floyd(graph, FromVertex, ToVertex);
        }
    }
}
