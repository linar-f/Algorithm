using System;

namespace Algoritm.Lesson1
{
    class Program
    {
        static string PrimeNumber(int number)
        {
            int d = 0;
            int i = 2;
            string answer = "";

            while (i < number)
            {
                if (number % i == 0)
                {
                    d += 1;
                }
                i += 1;
            }
            if (d == 0)
            {
                answer = "Простое";
                Console.WriteLine(answer);
            }
            else
            {
                answer = "Не простое";
                Console.WriteLine(answer);
            }
            return answer;
        }

        static void Test(int num, string expected)
        {
            if (PrimeNumber(num) == expected)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
        static void Main(string[] args)
        {
            int number;
            string expected = "";

            number = 2;
            expected = "Простое";
            Console.WriteLine(number);
            Test(number, expected);

            number = 4;
            expected = "Не простое";
            Console.WriteLine(number);
            Test(number, expected);

            number = 9;
            expected = "Не простое";
            Console.WriteLine(number);
            Test(number, expected);

            number = 11;
            expected = "Простое";
            Console.WriteLine(number);
            Test(number, expected);

            number = 17;
            expected = "Простое";
            Console.WriteLine(number);
            Test(number, expected);

            Console.ReadLine();
        }
    }
}
