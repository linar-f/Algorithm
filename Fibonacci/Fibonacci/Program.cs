using System;

namespace Fibonacci
{
    class Program
    {
        static long FiboRec(int n)
        {
            if (n == 0 || n == 1)
            {
                return (n);
            }
            else
            {
                return (FiboRec(n - 1) + FiboRec(n - 2));
            }

        }

        static long FiboCycle(int n)
        {
            int n0 = 0;
            int n1 = 1;
            int fibo = n1;
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    for (int i = 1; i < n; i++)
                    {
                        fibo = n0 + n1;
                        n0 = n1;
                        n1 = fibo;
                    }
                    return fibo;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите n:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Значение числа Фибоначчи (рекурсия): {FiboRec(n)}");
            Console.WriteLine($"Значение числа Фибоначчи (цикл): {FiboCycle(n)}");
            Console.ReadLine();
        }
    }
}
