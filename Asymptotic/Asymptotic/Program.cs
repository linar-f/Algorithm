using System;

namespace Asymptotic
{
    class Program
    {
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; //O(1)
            for (int i = 0; i < inputArray.Length; i++) //O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) //O(N)
                    {
                        int y = 0; //O(1)

                        if (j != 0) //O(1)
                        {
                            y = k / j; //O(1) - действие выполняется почти для всех j
                        }

                        sum += inputArray[i] + i + k + j + y; //O(1)
                    }
                }
            }

            return sum; //O(1)
            //O(1) + O(N)*O(N)*O(N)*(O(1)+O(1)+O(1)+O(1)) = 
            //O(1) + O(N^3)O(4) = O(1) + O(4*N^3) = O(N^3)
            //Согласно правилам расчета асимпототической сложности
            //пренебрегаем слагаемым O(1), оно много меньше O(N) и тем более O(N^3)
            //аналогично пренебрегаем постоянным множителем 4.

        }
        static void Main(string[] args)
        {

        }
    }
}
