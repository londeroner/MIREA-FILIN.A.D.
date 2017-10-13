
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерности для случайно сгенерированной матрицы через пробел: ");
            string[] str = Console.ReadLine().Split();
            int L1 = int.Parse(str[0]);
            int L2 = int.Parse(str[1]);
            int[,] MainMas = new int[L1, L2];
            Random rnd = new Random();
            int k = 0, m = 0, min = 101;

            for (int i = 0; i < L1; i++)
            {
                for (int j = 0; j < L2; j++)
                {
                    MainMas[i, j] = rnd.Next(1, 100);
                    if (MainMas[i, j] < min)
                    {
                        min = MainMas[i, j];
                        k = i;
                        m = j;
                    }
                }
            }

            for (int i = 0; i < L1; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < L2; j++)
                {
                    Console.Write("{0} ", MainMas[i, j]);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < L2; i++)
            {
                int t = MainMas[0, i];
                MainMas[0, i] = MainMas[L1 - 1, L2 - i - 1];
                MainMas[L1 - 1, L2 - i - 1] = t;
            }

            for (int i = 0; i < L1; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < L2; j++)
                {
                    Console.Write("{0} ", MainMas[i, j]);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            int[,] SecMas = new int[L1 - 1, L2 - 1];

            for (int i = 0; i < L1; i++)
            {
                for (int j = 0; j < L2; j++)
                {
                    if (i >= k && j >= m)
                    {
                        SecMas[i - 1, j - 1] = MainMas[i, j];
                    }
                    else if (i >= k && j < m)
                    {
                        SecMas[i - 1, j] = MainMas[i, j];
                    }
                    else if (i < k && j >= m)
                    {
                        SecMas[i, j - 1] = MainMas[i, j];
                    }
                    else
                    {
                        SecMas[i, j] = MainMas[i, j];
                    }
                }
            }

            for (int i = 0; i < L1; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < L2; j++)
                {
                    Console.Write("{0} ", SecMas[i, j]);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            

            Console.ReadLine();
        }
    }
}
