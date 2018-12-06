using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advancedAlgorithmBinarySearch
{
    class Program
    {
        // Part One (BinarySearchIterative)
        public static object BinarySearchIterative(int[] inputArray, int key, int min, int max)
        {
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return "Nil";
        }
        // Part Two (BinarySearchRecursive)
        public static object BinarySearchRecursive(int[] inputArray, int key, int min, int max)
        {
            if (min > max)
            {
                return "Nil";
            }
            else
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    return BinarySearchRecursive(inputArray, key, min, mid - 1);
                }
                else
                {
                    return BinarySearchRecursive(inputArray, key, mid + 1, max);
                }
            }
        }
        //  new method for linear search code
        public static object LinearSearch(int[] inputArray, int key, int min, int max)
        {
            for (int x = min; x < max; x++)
            {
                if (key == inputArray[x])
                {
                    return x;
                }
            }
            return "Nil";
        }

        // Parth Three (Main)
        static void Main(string[] args)
        {
            // random number generator
            Random randSearchValue = new Random();
            // max size of the arrays
            int max_size = 10000;
            // setting max size of array so reasonable numbers can be retrived  
            int size = (max_size * 10) / 100;

            // integer array of size max
            int[] bigArray = new int[max_size];
            // populate array
            for (int x = 0; x < max_size; x++)
            {
                bigArray[x] = x;
            }
            
            int[] targetArray = new int[size];

            // looping through the array
            for (int Counter = 0; Counter < 100; Counter++)
            {
                // populate array with random targets
                for (int y = 0; y < size; y++)
                {
                    targetArray[y] = randSearchValue.Next(0, max_size);
                }

                // creating the stopwatch and starting it 
                var s1 = Stopwatch.StartNew();
                // looping through array searching random data
                for (int testCounter = 1; testCounter < size; testCounter++)
                {
                    int key = Array.BinarySearch<int>(bigArray, targetArray[testCounter]);
                }
                // stop the stopwatch
                s1.Stop();

                // creating the stopwatch and starting it 
                var s2 = Stopwatch.StartNew();
                // looping through array searching for random data
                for (int testCounter = 0; testCounter < size; testCounter++)
                {
                    BinarySearchIterative(bigArray, targetArray[testCounter], 0, max_size);
                }
                // stop the stopwatch
                s2.Stop();

                // creating the stopwatch and starting it
                var s3 = Stopwatch.StartNew();
                // looping through array searching for random data
                for (int testCounter = 0; testCounter < size; testCounter++)
                {
                    BinarySearchRecursive(bigArray, targetArray[testCounter], 0, max_size);
                }
                // stop the stopwatch
                s3.Stop();
                // creating the stopwatch and starting it
                var s4 = Stopwatch.StartNew();
                // looping through array searching for random data
                for (int testCounter = 0; testCounter < size; testCounter++)
                {
                    LinearSearch(bigArray, targetArray[testCounter], 0, max_size);
                }
                // stop the stopwatch
                s4.Stop();

                // writing data to textfile
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:output.txt", true))
                {
                    file.Write(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString() + ",");
                    file.Write(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString() + ",");
                    file.Write(((double)(s3.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString() + ",");
                    file.Write(((double)(s4.Elapsed.TotalMilliseconds * 1000000) / max_size).ToString());
                    file.WriteLine();
                }

            }
            
        }
    }
}
