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
            Console.WriteLine();
            Console.Write("Введите нижнее и верхнее ограничение для значений рандомных чисел: ");
            string[] strrand = Console.ReadLine().Split();

            for (int i = 0; i < L1; i++)
            {
                for (int j = 0; j < L2; j++)
                {
                    MainMas[i, j] = rnd.Next(int.Parse(strrand[0]), int.Parse(strrand[1]));
                }
            }

            Console.WriteLine("Начальный массив:");
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
                for (int j = 0; j < L2; j++)
                {
                    if (MainMas[i, j] < min)
                    {
                        min = MainMas[i, j];
                        k = i;
                        m = j;
                    }
                }

            Console.WriteLine("Массив с перевернутыми поменяными первой и последней строкой:");
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

            for (int i = 0; i < L1 - 1; i++)
            {
                for (int j = 0; j < L2 - 1; j++)
                {
                    if (i >= k && j >= m)
                    {
                        SecMas[i, j] = MainMas[i + 1, j + 1];
                    }
                    else if (i >= k && j < m)
                    {
                        SecMas[i, j] = MainMas[i + 1, j];
                    }
                    else if (i < k && j >= m)
                    {
                        SecMas[i, j] = MainMas[i, j + 1];
                    }
                    else
                    {
                        SecMas[i, j] = MainMas[i, j];
                    }
                }
            }

            Console.WriteLine("Массив с удаленной строкой и столбцом с самым маленьким элементом:");
            for (int i = 0; i < L1-1; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < L2-1; j++)
                {
                    Console.Write("{0} ", SecMas[i, j]);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Введите массив, конец строки запятая, конец ввода точка:");
            Stack<int> myst = new Stack<int>();
            string[] strin;
            bool end = false;
            int L3 = 0, L4 = 0;
            while (!end)
            {
                L3++;
                strin = Console.ReadLine().Split();
                L4 = strin.Length;
                for (int i = 0; i < strin.Length - 1; i++)
                {
                    myst.Push(int.Parse(strin[i]));
                }
                if (strin[strin.Length - 1][strin[strin.Length - 1].Length - 1] == ',')
                {
                    string[] lastelement = strin[strin.Length - 1].Split(',');
                    myst.Push(int.Parse(lastelement[0]));
                }
                else {
                    string[] lastelement = strin[strin.Length - 1].Split('.');
                    myst.Push(int.Parse(lastelement[0]));
                    end = !end;
                }
            }

            

            int[,] inmas = new int[L3, L4];

            

            for (int i = L3 - 1; i > -1; i--)
            {
                for (int j = L4 - 1; j > -1; j--)
                {
                    inmas[i, j] = myst.Pop();
                    
                    
                }
            }
            
            Console.WriteLine();

            L4 = L4 - 1;
            L3 = L3 - 1;
            L2 = L2 - 2;
            L1 = L1 - 2;
            int[,] masres = new int[L1 + 1, L4 + 1];
            if (L2 == L3)
                for (int i = 0; i <= L1; i++)
                {
                    for (int j = 0; j <= L4; j++)
                    {
                        int res = 0;
                        for (int n = 0; n <= L3; n++)
                        {
                            res += SecMas[i, n] * inmas[n, j];
                        }
                        masres[i, j] = res;
                    }
                }
            else { Console.Write("Невозможно перемножить матрицы"); Console.ReadLine(); return; }

            Console.WriteLine("Результат произведения матриц:");
            for (int i = 0; i <= L1; i++)
            {
                Console.WriteLine();
                for (int j = 0; j <= L4; j++)
                {
                    Console.Write("{0} ", masres[i, j]);
                }
            }

            Console.ReadLine();
        }
    }
}
