using System;
using System.Threading;

namespace Horse
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 5;
            const int M = 5;
            const int numberCell = N * M;

            byte[,] board = new byte[N, M];
            for (int n = 0; n < N; n++)
                for (int m = 0; m < M; m++)
                {
                    board[n, m] = 0;
                }

            Step startStep = new Step(0, 0); //Начальное поле
            Step step = startStep;
            int i = step.line;
            int j = step.column;
            board[i, j] = 1;
            int count = 1;

            while (count != numberCell)
            {
                //Console.WriteLine(count);
                if ((i + 1) < 5 && (j + 2) < 5 && (step.nextSteps[0] == null) && board[i + 1, j + 2] == 0)
                {
                    i = i + 1;
                    j = j + 2;
                    board[i, j] = 1;
                    count = count + 1;
                    step.addStep(step, i, j, 0);
                    step = step.nextSteps[0];
                }
                else if ((i + 2) < 5 && (j + 1) < 5 && (step.nextSteps[1] == null) && board[i + 2, j + 1] == 0)
                {
                    board[i + 2, j + 1] = 1;
                    count = count + 1;
                    i = i + 2;
                    j = j + 1;
                    step.addStep(step, i, j, 1);
                    step = step.nextSteps[1];
                }
                else if ((i + 2) < 5 && (j - 1) >= 0 && (step.nextSteps[2] == null) && board[i + 2, j - 1] == 0)
                {
                    board[i + 2, j - 1] = 1;
                    count = count + 1;
                    i = i + 2;
                    j = j - 1;
                    step.addStep(step, i, j, 2);
                    step = step.nextSteps[2];
                }
                else if ((i + 1) < 5 && (j - 2) >= 0 && (step.nextSteps[3] == null) && board[i + 1, j - 2] == 0)
                {
                    board[i + 1, j - 2] = 1;
                    count = count + 1;
                    i = i + 1;
                    j = j - 2;
                    step.addStep(step, i, j, 3);
                    step = step.nextSteps[3];
                }
                else if ((i - 1) >= 0 && (j - 2) >= 0 && (step.nextSteps[4] == null) && board[i - 1, j - 2] == 0)
                {
                    board[i - 1, j - 2] = 1;
                    count = count + 1;
                    i = i - 1;
                    j = j - 2;
                    step.addStep(step, i, j, 4);
                    step = step.nextSteps[4];
                }
                else if ((i - 2) >= 0 && (j - 1) >= 0 && (step.nextSteps[5] == null) && board[i - 2, j - 1] == 0)
                {
                    board[i - 2, j - 1] = 1;
                    count = count + 1;
                    i = i - 2;
                    j = j - 1;
                    step.addStep(step, i, j, 5);
                    step = step.nextSteps[5];
                }
                else if ((i - 2) >= 0 && (j + 1) < 5 && (step.nextSteps[6] == null) && board[i - 2, j + 1] == 0)
                {
                    board[i - 2, j + 1] = 1;
                    count = count + 1;
                    i = i - 2;
                    j = j + 1;
                    step.addStep(step, i, j, 6);
                    step = step.nextSteps[6];
                }
                else if ((i - 1) >= 0 && (j + 2) < 5 && (step.nextSteps[7] == null) && board[i - 1, j + 2] == 0)
                {
                    board[i - 1, j + 2] = 1;
                    count = count + 1;
                    i = i - 1;
                    j = j + 2;
                    step.addStep(step, i, j, 7);
                    step = step.nextSteps[7];
                }
                else
                {
                    step.status = false;
                    board[i, j] = 0;
                    step = step.prevStep;
                    i = step.line;
                    j = step.column;
                    count = count - 1;
                }
                Console.SetCursorPosition(0, 0);
                for (int ii = 0; ii < 5; ii++)
                {
                    for (int jj = 0; jj < 5; jj++)
                    {
                        Console.Write($"{board[ii, jj]} ");
                    }
                    Console.WriteLine();
                }
                //Thread.Sleep(10);
            }
            Console.WriteLine();
            int count1 = 0;
            Step step1 = startStep;
            while (count1 != numberCell)
            {
                if (step1.status == true)
                {
                    count1 = count1 + 1;
                    Console.WriteLine($"{count1}-й ход: ({step1.line}, {step1.column})");
                    for (int k = 0; k < 8; k++)
                    {
                        if (step1.nextSteps[k] != null && step1.nextSteps[k].status == true)
                        {
                            step1 = step1.nextSteps[k];
                            break;
                        }
                    }    
                }
            }
        }
    }
}
