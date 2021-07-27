using System;
using System.Collections.Generic;

namespace Bucket
{
    class Program
    {
        static int[] Bucketsort(int[] array, int minValue, int maxValue)
        {
            int arrayLength = array.Length;
            if (arrayLength < 2 || minValue == maxValue)
            {
                return (array);
            }
            const int numBuckets = 10;
            List<int>[] arrayOfBuckets = new List<int>[numBuckets];
            int range = maxValue - minValue;
            int[] min = new int[numBuckets];
            int[] max = new int[numBuckets];
            int[] sortArray = new int[arrayLength];
            int[] mergeArray = new int[arrayLength];
            int k = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                int index = (array[i] * (numBuckets-1)) / range;
                if (arrayOfBuckets[index] != null)
                {
                    arrayOfBuckets[index].Add(array[i]);
                }
                else
                {
                    arrayOfBuckets[index] = new List<int>(1);
                    arrayOfBuckets[index].Add(array[i]);
                }
                if (array[i] < min[index])
                {
                    min[index] = array[i];
                }
                if (array[i] > max[index])
                {
                    max[index] = array[i];
                }
            }
            for (int i = 0; i < numBuckets; i++)
            {
                if (arrayOfBuckets[i] != null)
                {
                    int[] newArray = arrayOfBuckets[i].ToArray();
                    sortArray = Bucketsort(newArray, min[i], max[i]);
                    for (int j = 0; j < sortArray.Length; j++)
                    {
                        mergeArray[k] = sortArray[j];
                        k = k + 1;
                    }
                }
            }
            return (mergeArray);
        }
        static void Main(string[] args)
        {
            const int numberElements = 20;
            int[] startArray = new int[numberElements];
            Random rand = new Random();
            int minimum = 0;
            int maximum = 0;
            for (int i = 0; i < numberElements; i++)
            {
                startArray[i] = rand.Next(1, 100);
                if (startArray[i] < minimum)
                {
                    minimum = startArray[i];
                }
                if (startArray[i] > maximum)
                {
                    maximum = startArray[i];
                }
            }
            for (int i = 0; i < numberElements; i++)
            {
                Console.Write($"{startArray[i]} ");
            }
            Console.WriteLine();

            int[] sortArray = Bucketsort(startArray, minimum, maximum);
            for (int i = 0; i < numberElements; i++)
            {
                Console.Write($"{sortArray[i]} ");
            }
            Console.ReadLine();
        }
    }
}
