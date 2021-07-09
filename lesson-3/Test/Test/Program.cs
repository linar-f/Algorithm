using System;
using System.Diagnostics;

namespace Test
{
    class PointClass
    {
        public float x;
        public float y;

        public static float distPC(PointClass p1, PointClass p2)
        {
            float distance = (float)Math.Sqrt(Math.Abs(Math.Pow((p2.x - p1.x), 2) - Math.Pow((p2.y - p1.y), 2)));
            return distance;
        }
    }

    struct PointStruct
    {
        public float x;
        public float y;

        public static float distPS(PointStruct p1, PointStruct p2)
        {
            float distance = (float)Math.Sqrt(Math.Abs(Math.Pow((p2.x - p1.x), 2) - Math.Pow((p2.y - p1.y), 2)));
            return distance;
        }

        public static float distPSsquere(PointStruct p1, PointStruct p2)
        {
            float distance = (float)(Math.Abs(Math.Pow((p2.x - p1.x), 2) - Math.Pow((p2.y - p1.y), 2)));
            return distance;
        }
    }
    
    struct PointDubleStruct
    {
        public double x;
        public double y;

        public static double distPDS(PointDubleStruct p1, PointDubleStruct p2)
        {
            double distance = Math.Sqrt(Math.Abs(Math.Pow((p2.x - p1.x), 2) - Math.Pow((p2.y - p1.y), 2)));
            return distance;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int count = 12; //количество генерируемых точек
            int numOfRep = 100000; //количество повторений подсчета расстояния
            //Класс (float)
            Random rand = new Random();
            float[] x = new float[count];
            float[] y = new float[count];
            for (int i = 0; i < count; i++)
            {
                x[i] = (float)rand.Next(-1000000000, 1000000000);
                y[i] = (float)rand.Next(-1000000000, 1000000000);
            }
            PointClass Point1 = new PointClass();
            PointClass Point2 = new PointClass();
            Console.WriteLine("1.Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).");
            double summ = 0;
            for (int i = 0; i < count - 1; i++)
            {
                Stopwatch sw = new Stopwatch();
                Point1.x = x[i];
                Point1.y = y[i];
                Point2.x = x[i + 1];
                Point2.y = y[i + 1];
                sw.Start();
                for (int k = 0; k < numOfRep; k++ )
                {
                    float dist = PointClass.distPC(Point1, Point2);
                }
                sw.Stop();
                summ = summ + sw.ElapsedMilliseconds;
            }
            Console.WriteLine($"Time: {summ}");
            Console.WriteLine();

            //Структура (float)
            PointStruct PS1 = new PointStruct();
            PointStruct PS2 = new PointStruct();
            Console.WriteLine("2.Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).");
            summ = 0;
            for (int i = 0; i < count - 1; i++)
            {
                Stopwatch sw = new Stopwatch();
                PS1.x = x[i];
                PS1.y = y[i];
                PS2.x = x[i + 1];
                PS2.y = y[i + 1];
                sw.Start();
                for (int k = 0; k < numOfRep; k++)
                {
                    float dist = PointStruct.distPS(PS1, PS2);
                }
                sw.Stop();
                summ = summ + sw.ElapsedMilliseconds;
            }
            Console.WriteLine($"Time: {summ}");
            Console.WriteLine();

            //Структура (double)
            Random randD = new Random();
            double[] xD = new double[count];
            double[] yD = new double[count];
            for (int i = 0; i < count; i++)
            {
                x[i] = rand.Next(-100000000, 100000000);
                y[i] = rand.Next(-100000000, 100000000);
            }
            PointDubleStruct PDS1 = new PointDubleStruct();
            PointDubleStruct PDS2 = new PointDubleStruct();
            Console.WriteLine("3.Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).");
            summ = 0;
            for (int i = 0; i < count - 1; i++)
            {
                Stopwatch sw = new Stopwatch();
                PDS1.x = x[i];
                PDS1.y = y[i];
                PDS2.x = x[i + 1];
                PDS2.y = y[i + 1];
                sw.Start();
                for (int k = 0; k < numOfRep; k++)
                {
                    double dist = PointDubleStruct.distPDS(PDS1, PDS2);
                }
                sw.Stop();
                summ = summ + sw.ElapsedMilliseconds;
            }
            Console.WriteLine($"Time: {summ}");
            Console.WriteLine();

            //Структура (float) без квадратного корня
            PointStruct PS3 = new PointStruct();
            PointStruct PS4 = new PointStruct();
            Console.WriteLine("4. Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).");
            summ = 0;
            for (int i = 0; i < count - 1; i++)
            {
                Stopwatch sw = new Stopwatch();
                PS3.x = x[i];
                PS3.y = y[i];
                PS4.x = x[i + 1];
                PS4.y = y[i + 1];
                sw.Start();
                for (int k = 0; k < numOfRep; k++)
                {
                    float dist = PointStruct.distPSsquere(PS1, PS2);
                }
                sw.Stop();
                summ = summ + sw.ElapsedMilliseconds;
            }
            Console.WriteLine($"Time: {summ}");
            Console.ReadLine();
        }
    }
}

