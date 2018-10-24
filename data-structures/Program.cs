using System;
using System.Collections.Generic;

namespace data_structures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 5, 12, 9, 8, 5, 9 };
            int[,] matrix = { { 5, -1, 8, 2 }, { 0, 5, 2, 1 }, { 6, 1, -1, 2 }, { 5, 6, 7, -5 } };

            double lab1Result = GetResult(81, 3); // 9.51245672686636
            bool lab2Result = CheckMinMaxMultiplicity(7225548, 2); // True
            int lab3Result = CountSingleElementsQuantity(array); // 3
            int[] lab4Result = GetLineSumArray(matrix); // [10, 100, 2, 0]
            int lab5Result = CheckMirrorWordsQuantity("CoooC asfff fffff Lfsfdl"); // 2

            Console.WriteLine("Lab 1: " + lab1Result);
            Console.WriteLine("Lab 2: " + lab2Result);
            Console.WriteLine("Lab 3: " + lab3Result);
            Console.WriteLine("Lab 4: " + string.Join(',', lab4Result));
            Console.WriteLine("Lab 5: " + lab5Result);
        }

        static double GetResult(int a, int n) {
            double result = n > 0 ? a : 0;

            for (int i = 1; i < n; i++) {
                result = a + Math.Sqrt(result);
            }

            return Math.Sqrt(result);
        }

        static bool CheckMinMaxMultiplicity(int natureNumber, int checkedNumber)
        {
            int min;
            int max;

            SetMinMaxDigits(natureNumber, out min, out max);

            return ((min + max) % checkedNumber) == 0;
        }

        static void SetMinMaxDigits(int number, out int min, out int max)
        {
            int[] digitsArray = Array.ConvertAll(number.ToString().ToCharArray(), x => (int)x);
            Array.Sort(digitsArray);

            min = digitsArray[0];
            max = digitsArray[digitsArray.Length - 1];
        }

        static int CountSingleElementsQuantity<T>(T[] array)
        {
            int result = 0;
            Dictionary<T, int> elementsCounter = new Dictionary<T, int>();

            foreach (T el in array)
            {
                if (elementsCounter.ContainsKey(el))
                {
                    elementsCounter[el] += 1;
                }
                else
                {
                    elementsCounter.Add(el, 1);
                }
            }

            foreach (int elQuantity in elementsCounter.Values)
            {
                if (elQuantity == 1)
                {
                    result++;
                }
            }

            return result;
        }

        static int[] GetLineSumArray(int[,] matrix)
        {
            int matrixSize = matrix.GetLength(0);
            int[] result = new int[matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                int lineSum = 0;
                bool isCount = false;

                for (int j = 0; j < matrixSize; j++)
                {
                    if (isCount)
                    {
                        lineSum += matrix[i, j];
                    }

                        if (matrix[i, j] < 0)
                    {
                        isCount = true;
                    }
                }

                result[i] = isCount ? lineSum : 100;
            }

            return result;
        }

        static int CheckMirrorWordsQuantity(string str)
        {
            int result = 0;
            string[] words = str.Replace(System.Environment.NewLine, "").Split(' ');

            foreach (string word in words)
            {
                if (word[0] == word[word.Length - 1])
                {
                    result++;
                }
            }

            return result;
        }
    }
}
