using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.Classes;

namespace SeaBattle
{
    class SeaBattle
    {
        static void game()
        {
            Console.Clear();
            bool Game = true;
            bool GameStarted = false;
            short player = 1;
            Desk desk1 = new Desk();
            Desk desk2 = new Desk();
            int[] Ships1 = new int[4];
            int[] Ships2 = new int[4];
            for (int i = 1, j = 4; i <= 4; i++, j--)
            {
                Ships1[i - 1] = j;
                Ships2[i - 1] = j;
            }
            bool ShipCreate1 = false;
            bool ShipCreate2 = false;

            while (Game)
            {
                if (GameStarted == true)
                {
                    desk1.DrawDesk(0, 4);
                    desk2.DrawDesk(40,4);
                }

                Console.SetCursorPosition(0,0);
                Console.Write("Ввод: ");
                if (!GameStarted)
                {
                    Console.Write("Что-бы начать, введите 1 для одиночной игры против компьютера, или 2 для игры вдвоем. ");
                }
                string input = Console.ReadLine();

                

                switch (input[0])
                {
                    case 'h'/*help*/:
                        Console.WriteLine("help - помощь, save - сохранить текущие игровые поля в файл, load - загрузить последние сохраненные поля из файла, quit - закрыть, restart - начать заново");
                        break;

                    case 's'/*save*/:
                        if (GameStarted)
                            Console.WriteLine("Еще не реализовано");
                        else Console.WriteLine("Сначала начните игру");
                        break;

                    case 'l'/*save*/: Console.WriteLine("Еще не реализовано");
                        break;

                    case 'q'/*quit*/: Environment.Exit(0);
                        break;

                    case 'r'/*restart*/: game();
                        break;

                    case '1':
                        if (GameStarted == false)
                        {
                            GameStarted = true;
                            Console.Clear();
                            Console.WriteLine("Введите начальные и конечные координаты x1 y1 x2 y2 вашего корабля через пробел. Если ваш корабль занимает одну клетку, введите только две координаты. Вы можете ввести:");
                            Console.WriteLine("1 Корабль размера 4 клетки, 2 корабля размера 3 клетки, 3 корабля размера 2 клетки, и 4 корабля размера 1 клетку. ");
                            while (!ShipCreate1)
                            {
                                string[] shipCreate = Console.ReadLine().Split();
                                if (shipCreate.Length == 2)
                                {
                                    int x = int.Parse(shipCreate[0]);
                                    int y = int.Parse(shipCreate[1]);
                                    if (x > 0 && x < 11 && y > 0 && y < 11 && !desk1.ShipDesk[x-1, y-1])
                                    {
                                        if (Ships1[0] != 0)
                                        {
                                            desk1.CreateShip(x, y);
                                            Ships1[0]--;
                                        }
                                        else { Console.WriteLine("Слишком много кораблей этого типа"); }
                                    }
                                    else Console.WriteLine("Введено неверное значение");
                                }
                                if (shipCreate.Length == 4)
                                {
                                    int x1 = int.Parse(shipCreate[0]);
                                    int y1 = int.Parse(shipCreate[1]);
                                    int x2 = int.Parse(shipCreate[2]);
                                    int y2 = int.Parse(shipCreate[3]);
                                    if (x1 > 0 && x1 < 11 && y1 > 0 && y1 < 11 && x2 > 0 && x2 < 11 && y2 > 0 && y2 < 11)
                                    {
                                        int ShipLength = desk1.CreateShip(x1,y1,x2,y2);
                                        if (ShipLength == -1)
                                            Console.WriteLine("Введено неверное значение");
                                        else Ships1[ShipLength]--;
                                    }
                                }
                                Console.WriteLine("Корабль установлен");
                                if (Ships1[0] == 0 && Ships1[1] == 0 && Ships1[2] == 0 && Ships1[3] == 0)
                                    ShipCreate1 = true;
                            }
                            Console.Clear();
                            Console.WriteLine("Первый игрок расставил корабли");
                            Console.WriteLine("Введите начальные и конечные координаты x1 y1 x2 y2 вашего корабля через пробел. Если ваш корабль занимает одну клетку, введите только две координаты. Вы можете ввести:");
                            Console.Write("1 Корабль размера 4 клетки, 2 корабля размера 3 клетки, 3 корабля размера 2 клетки, и 4 корабля размера 1 клетку. ");
                            while (!ShipCreate2)
                            {
                                ShipCreate2 = true;
                            }
                        }
                        else
                        {
                            if (PlayerTurn(input))
                            {
                                string[] stroke = input.Split();
                                int x = int.Parse(stroke[0]); int y = int.Parse(stroke[1]);
                                x--; y--;
                                if (player % 2 == 1)
                                {
                                    if (!desk1.ShipDesk[x, y])
                                        desk1.GameDesk[x, y] = 1;
                                    else desk1.GameDesk[x, y] = 2;
                                    player++;
                                }
                                else if (player % 2 == 0)
                                {
                                    if (!desk2.ShipDesk[x, y])
                                        desk2.GameDesk[x, y] = 1;
                                    else desk2.GameDesk[x, y] = 2;
                                    player++;
                                }
                                
                            }
                        }
                        break;

                    default:
                        if (PlayerTurn(input))
                        {
                            string[] stroke = input.Split();
                            int x = int.Parse(stroke[0]); int y = int.Parse(stroke[1]);
                            x--; y--;
                            if (player % 2 == 1)
                            {
                                if (!desk1.ShipDesk[x, y])
                                    desk1.GameDesk[x, y] = 1;
                                else desk1.GameDesk[x, y] = 2;
                                player++;
                            }
                            else if (player % 2 == 0)
                            {
                                if (!desk2.ShipDesk[x, y])
                                    desk2.GameDesk[x, y] = 1;
                                else desk2.GameDesk[x, y] = 2;
                                player++;
                            }

                        }
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
        
        static bool PlayerTurn(string str)
        {
            string[] stroke = str.Split(' ');
            if (stroke.Length == 2)
                if ((int.TryParse(stroke[0].ToString(), out int value)) && (int.TryParse(stroke[1].ToString(), out int value1)))
                {
                    return true;
                }
                else { Console.WriteLine("Введено неверное значение"); return false; }
            else { Console.WriteLine("Введено неверное значение"); return false; }
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("В любой момент вы можете ввести команду help для отображения всех возможных комбинаций");
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadLine();
            game();
        }
    }
}
