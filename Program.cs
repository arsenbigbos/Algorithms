﻿// C# implementation of ShellSort
using System;

class ShellSort
{
    /* An utility function to
	print array of size n*/
    static void printArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }

    /* function to sort arr using shellSort */
    int sort(int[] arr)
    {
        int n = arr.Length;

        // Start with a big gap,
        // then reduce the gap
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            // Do a gapped insertion sort for this gap size.
            // The first gap elements a[0..gap-1] are already
            // in gapped order keep adding one more element
            // until the entire array is gap sorted
            for (int i = gap; i < n; i += 1)
            {
                // add a[i] to the elements that have
                // been gap sorted save a[i] in temp and
                // make a hole at position i
                int temp = arr[i];

                // shift earlier gap-sorted elements up until
                // the correct location for a[i] is found
                int j;
                for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    arr[j] = arr[j - gap];

                // put temp (the original a[i])
                // in its correct location
                arr[j] = temp;

            }
            printArray(arr);
        }
            Array.Reverse(arr);
            Console.WriteLine("-------------");
        for (int gap = n / 2; gap > 0; gap /= 4)
        { 
            for (int i = gap; i < n; i += 1)
            {
                if (arr[i] != 0)
                {
                    // add a[i] to the elements that have
                    // been gap sorted save a[i] in temp and
                    // make a hole at position i
                    int temp = arr[i];

                    // shift earlier gap-sorted elements up until
                    // the correct location for a[i] is found
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                        arr[j] = arr[j - gap];

                    // put temp (the original a[i])
                    // in its correct location
                    arr[j] = temp;
                    printArray(arr);
                }
            }
        }
        return 0;
    }

    // Driver method
    public static void Main()
    {
        int[] arr = { 0, 1, 2, 0, 1, 1, 2, 0, 1, 0, 2, 0 };
        Console.Write("Array in scaling sorting :\n");
        printArray(arr);

        ShellSort ob = new ShellSort();
        ob.sort(arr);

        Console.Write("Array after (1,2,0) sorting :\n");
        printArray(arr);
    }
}

// This code is contributed by nitin mittal.
