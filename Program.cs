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
            int[,] MainMas = new int[10, 10];
            Random rnd = new Random();
            int k=0, m=0, min = 101;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    MainMas[i, j] = rnd.Next(1, 100);
                    if (MainMas[i,j] < min)
                    {
                        min = MainMas[i, j];
                        k = i;
                        m = j;
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("{0} ", MainMas[i, j]);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                int t = MainMas[0, i];
                MainMas[0, i] = MainMas[9,9-i];
                MainMas[9, 9 - i] = t;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("{0} ", MainMas[i, j]);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            int[,] SecMas = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i >= k && j >= m)
                    {
                        SecMas[i, j] = MainMas[i + 1, j + 1];                   
                    }
                    else if (i >= k && j < m)
                    {
                        SecMas[i, j] = MainMas[i+1, j];
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

            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 9; j++)
                {
                    Console.Write("{0} ", SecMas[i, j]);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Введите массив 9 на 9");
            Console.WriteLine();

            int[,] InMas = new int[9,9];
            int CountStroke = 0;

            while (CountStroke < 9)
            {
                string[] str = Console.ReadLine().Split();

                for (int i = 0; i < 9; i++)
                {
                    if (i != 8 && CountStroke != 8) InMas[CountStroke, i] = int.Parse(str[i]);
                    else if (i == 8 && CountStroke != 8)
                    {
                        string[] strdop = str[str.Length - 1].Split(',');
                        InMas[CountStroke, i] = int.Parse(strdop[0]);
                    }
                    else {
                        string[] strdop = str[str.Length - 1].Split('.');
                        InMas[CountStroke, i] = int.Parse(strdop[0]);
                    }
                    
                }

                CountStroke++;
            }

            int[,] ResMas = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                int res = 0;
                for (int j = 0; j < 9; j++)
                {
                    for (int l = 0; l < 9; l++)
                    {
                        res += SecMas[i, j] * InMas[j, l];
                    }
                }
            }

            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 9; j++)
                {
                    Console.Write("{0} ", ResMas[i, j]);
                }
            }

            Console.ReadLine();
        }
    }
}
