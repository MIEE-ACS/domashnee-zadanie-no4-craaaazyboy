using System;

namespace DZ4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, quantity = 0, maxI;
            double max, composition = 1;
            Random rand = new Random();


            do
            {
                Console.WriteLine("Введите размер массива");
                n = int.Parse(Console.ReadLine());
                if (n <= 0 || n > 100) Console.WriteLine("недопустимое значение");
            } while (n <= 0 || n > 100);
            double[] A = new double[n];
            for (int i = 0; i < n; i++)
            {
                A[i] = rand.Next(-999, 999) / 10.0;
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine();
            maxI = 0;
            max = A[maxI];
            Console.WriteLine("Введите C");
            int C = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                if (A[i] > C) quantity++;
                if (Math.Abs(A[i]) > Math.Abs(max))
                {
                    maxI = i;
                    max = A[i];
                }
            }
            Console.WriteLine("Произведение Элементов массива расположенных после максимального");
            if (maxI == n - 1)
            {
                Console.WriteLine("после максимального по модулю элемента нет других элеентов");
            }
            else
            {
                for (int i = maxI+1; i < n; i++)
                {
                    composition = composition * A[i];
                }
                Console.WriteLine($"{composition} ");
            }
            Console.WriteLine("Количество элементов больших C:");
            Console.WriteLine($"{quantity} ");
            int f = 1;
            while (f == 1)
            {
                f = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    if (A[i] >= 0 && A[i + 1] < 0)
                    {
                        double temp = A[i];
                        A[i] = A[i + 1];
                        A[i + 1] = temp;
                        f = 1;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("Двумерный массив");
            int N1, N2, k = 1, index = -1;
            do
            {
                Console.Write("Введите колличество строк массива:\t");
                N1 = int.Parse(Console.ReadLine());
                if (N1 <= 0 || N1 >= 100)
                {
                    Console.WriteLine("Некорректный размер массива.");
                }
            } while (N1 <= 0 || N1 >= 100);
            do
            {
                Console.Write("Введите колличество столбцов массива:\t");
                N2 = int.Parse(Console.ReadLine());
                if (N2 <= 0 || N2 >= 100)
                {
                    Console.WriteLine("Некорректный размер массива.");
                }
            } while (N2 <= 0 || N2 >= 100);
            Random randnew = new Random();
            int[,] M = new int[N1, N2];
            for (int i = 0; i < N1; i++)
            {
                for (int j = 0; j < N2; j++)
                {
                    M[i, j] = rand.Next(-10, 10);
                    Console.Write("{0}\t", M[i, j]);
                    if (k == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (M[i, j] == 0)
                        {
                            k = M[i, j];
                            index = j;
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("индекс певрого столбца,в котором есть нулевой элемент:");
            if (index == -1)
            {
                Console.WriteLine("Нулевого элемента нет в массиве");
            }
            else
            {
                Console.WriteLine($"{index} ");
            }
            Console.WriteLine("характеристика изначального массива:");
            int[] sum = new int[N1];
            for (int i = 0; i < N1; i++)
            {
                for (int j = 0; j < N2; j++)
                {
                    if (M[i, j] < 0 && M[i, j] % 2 == 0) sum[i] += Math.Abs(M[i, j]);

                }
                Console.WriteLine($"{sum[i]} ");
            }
            Console.WriteLine();
            int flag = 1, swap;
            while (flag == 1)
            {
                flag = 0;
                for (int i = 0; i < N1 - 1; i++)
                {
                    if (sum[i] < sum[i + 1])
                    {
                        swap = sum[i];
                        sum[i] = sum[i + 1];
                        sum[i + 1] = swap;
                        flag = 1;
                        for (int j = 0; j < N2; j++)
                        {
                            swap = M[i, j];
                            M[i, j] = M[i + 1, j];
                            M[i + 1, j] = swap;
                        }
                    }
                }
            }
            Console.WriteLine("массив отсортированный по характеристике:");
            for (int i = 0; i < N1; i++)
            {
                for (int j = 0; j < N2; j++)
                {
                    Console.Write("{0}\t", M[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("отсортированная по убыванию характеристика:");
            for (int i = 0; i < N1; i++)
            {
                Console.WriteLine($"{sum[i]} ");
            }
        }
    }
}
