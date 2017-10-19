using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Classes
{
    class Desk
    {
        public short[,] GameDesk = new short[10, 10];
        public bool[,] ShipDesk = new bool[10, 10];

        public void CreateShip(int x, int y)
        {
            ShipDesk[x - 1, y - 1] = true;
        }
        public int CreateShip(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2)
            {
                if (y2 < y1)
                {
                    if ((y1 - y2) > 0 && (y1 - y2) < 4)
                    {
                        for (int i = y2; i <= y1; i++)
                            ShipDesk[x1 - 1, i - 1] = true;
                        return y1 - y2;
                    }
                }
                else if (y2 > y1)
                {
                    if ((y2 - y1) > 0 && (y2 - y1) < 4)
                    {
                        for (int i = y1; i <= y2; i++)
                            ShipDesk[x1 - 1, i - 1] = true;
                        return y2 - y1;
                    }
                }
                else return -1;
            }
            else if (y1 == y2)
            {
                if (x2 < x1)
                {
                    if ((x1 - x2) > 0 && (x1 - x2) < 4)
                    {
                        for (int i = x2; i <= x1; i++)
                            ShipDesk[i - 1, y1 - 1] = true;
                        return x1 - x2;
                    }
                }
                else if (x2 > x1)
                {
                    if ((x2 - x1) > 0 && (x2 - x1) < 4)
                    {
                        for (int i = x1; i <= x2; i++)
                            ShipDesk[x1 - 1, i - 1] = true;
                        return x2 - x1;
                    }
                }
                else return -1;
            }
            else
                return -1;
            return -1;
        }

        public void DrawDesk(int x, int y)
        {
            int stroke = 0;
            Console.SetCursorPosition(x, y+stroke);
            stroke++;
            Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");
            Console.SetCursorPosition(x, y+stroke);
            stroke++;
            Console.WriteLine("   --------------------");
            Console.SetCursorPosition(x, y+stroke);
            stroke++;
            for (int i = 0; i < 10; i++)
            {
                if (i != 9)
                    Console.Write("{0} ", i + 1);
                else Console.Write("10");
                for (int j = 0; j < 21; j++)
                {
                    if (j % 2 == 0)
                        Console.Write("|");
                    else
                    {
                        switch(GameDesk[i,j/2])
                        {
                            case 0: Console.Write(" ");
                                break;
                            case 1: Console.Write("-");
                                break;
                            case 2: Console.Write("X");
                                break;
                        }
                    }
                }
                Console.WriteLine();
                Console.SetCursorPosition(x, y + stroke);
                stroke++;
                Console.WriteLine("   --------------------");
                Console.SetCursorPosition(x,y + stroke);
                stroke++;
            }
        }
    }
}
