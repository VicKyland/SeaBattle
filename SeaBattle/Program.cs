using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.Win32.SafeHandles;

namespace SeaBattle
{
    
    public class Ship
    {
        int x, y, direction, shipLength, field;

        public Ship( int x1, int y1, int direction1, int shipLength1, int field1 )
        {
            x = x1;
            y = y1;
            direction = direction1;
            shipLength = shipLength1;
            field = field1;
        }

        public void checkOnDeath( int[,] field )
        {
            int totalCells = shipLength;

            for (int i = x - 1; i < x + shipLength + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (true)
                    {
                        if (i >= 0 && j >= 0 && i < 10 && j < 10)
                        {
                            if (direction == 90)
                            {
                                if (field[j, i] == 2)
                                {
                                    totalCells--;
                                }
                            }
                            else
                            {
                                if (field[i, j] == 2)
                                {
                                    totalCells--;
                                }
                            }
                        }
                    }
                }
            }
            if ( totalCells == 0 )
            {
                for (int i = x - 1; i < x + shipLength + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (true)
                        {
                            if (i >= 0 && j >= 0 && i < 10 && j < 10)
                            {
                                if (direction == 90)
                                {
                                    if (field[j, i] == -1)
                                    {
                                        field[j, i] = 1;
                                    }
                                }
                                else
                                {
                                    if (field[i, j] == -1)
                                    {
                                        field[i, j] = 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }

    public class ShipArray
    {
        public Ship[] array = new Ship[10];

        public ShipArray(Ship[] arr) { array = arr; }

        public ShipArray () { }

        public void checkOnDeath(int[,] field)
        {
            foreach( Ship ship in array )
            {
                ship.checkOnDeath(field);
            }
        }


    }

    
    class Program
    {
        public static ShipArray shipArray1 = new ShipArray();
        public static ShipArray shipArray2 = new ShipArray();
        public static int[,] field0 = { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};

        static void Main(string[] args)
        {
            Random rand = new Random();

            int[,] field1 = { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};

            int[,] field2 = { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};

            int x = rand.Next(1, 9);
            int y = rand.Next(1, 9);
            int x1 = rand.Next(1, 9);
            int y1 = rand.Next(1, 9);
            int x2 = rand.Next(1, 9);
            int y2 = rand.Next(1, 9);
            int x3 = rand.Next(1, 9);
            int y3 = rand.Next(1, 9);
            int x4 = rand.Next(1, 9);
            int y4 = rand.Next(1, 9);
            int x5 = rand.Next(1, 9);
            int y5 = rand.Next(1, 9);
            int x6 = rand.Next(1, 9);
            int y6 = rand.Next(1, 9);
            int x7 = rand.Next(1, 9);
            int y7 = rand.Next(1, 9);
            field2[y, x] = 10;
            field2[y1, x1] = 10;
            field2[y2, x2] = 10;
            field2[y3, x3] = 10;
            field2[y4, x4] = 10;
            field2[y5, x5] = 10;
            field2[y6, x6] = 10;
            field2[y7, x7] = 10;

            bool game = true; // game loop
            bool preGame = true;
            string gameMode = "2p";
            int playerWin = 0;
            string answer;
            string version = "0.5";
            
            while (game)
            {
                Console.Clear();



                preGame = true;
                playerWin = 0;
                printNewSign(version);

                while (true)
                {
                    if (QuestionYorN("Start (y/n): "))
                    {
                        break;
                    }
                    else if (QuestionYorN("Exit (y/n): "))
                    {
                        preGame = false;
                        game = false;
                        break;
                    }
                }

                while (preGame)
                {
                    // Console.Write("2p or bot (2p/bot): ");
                    if ( gameMode == "2p" )
                    {
                        BuilderRandom(field1, 1);
                        BuilderRandom(field2, 2);
                        field2[y, x] = 0;
                        field2[y1, x1] = 0;
                        field2[y2, x2] = 0;
                        field2[y3, x3] = 0;
                        field2[y4, x4] = 0;
                        field2[y5, x5] = 0;
                        field2[y6, x6] = 0;
                        field2[y7, x7] = 0;

                        Console.Clear();

                        Question("\nPlease have the 2nd player turn away (y/n): ");
                        
                        Console.WriteLine("\n1st player's field: ");
                        ShowSpace(field1, true);

                        if ( QuestionContinue("Continue (y/n): ") )
                        {
                            game = false;
                            break;
                        }

                        Console.Clear();
                        
                        Question("\nPlease have the 1st player turn away (y/n): ");
                        
                        Console.WriteLine("\n2nd player's field: ");
                        ShowSpace(field2, true);

                        if (QuestionContinue("Continue (y/n): "))
                        {
                            game = false;
                            break;
                        }

                        Console.Clear();

                        while (true)
                        {
                            while (true)
                            {
                                // first player
                                Console.WriteLine("First player's turn");
                                ShowSpace(field2, false);

                                while (true)
                                {
                                    Console.Write("Please enter coords (like \'e2\' or \'E2\'): ");
                                    answer = Console.ReadLine();
                                    string symbols = "abcdefghijABCDEFGHIJ";
                                    bool exitOrNot = false;
                                    
                                    if (answer != "111ADMIN111")
                                    {
                                        if (answer != null)
                                        {
                                            if (answer.Length > 1)
                                            {
                                                if (Char.IsDigit(answer[1]))
                                                {
                                                    foreach (char c in symbols)
                                                    {
                                                        if (answer[0] == c)
                                                        {
                                                            exitOrNot = true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        playerWin = 1;
                                        break;
                                    }

                                    if (exitOrNot)
                                    {
                                        break;
                                    }
                                }

                                if (PlayersTurn(field2, answer))
                                {
                                    shipArray2.checkOnDeath(field2);
                                    Console.WriteLine();
                                    ShowSpace(field2, false);
                                    if (checkWin(field2) || playerWin == 1)
                                    {
                                        playerWin = 1;
                                    }
                                    break;
                                }
                                shipArray2.checkOnDeath(field2);
                                Console.WriteLine();
                                if (checkWin(field2) || playerWin == 1) 
                                {
                                    playerWin = 1;
                                    break;
                                }
                            }
                            
                            if (playerWin != 0)
                            {
                                break;
                            }

                            if (QuestionContinue("Continue (y/n): "))
                            {
                                game = false;
                                break;
                            }

                            Console.Clear();

                            while (true) {
                                // second player
                                Console.WriteLine("Second player's turn");
                                ShowSpace(field1, false);
                                while (true)
                                {
                                    Console.Write("Please enter coords (like \'e2\' or \'E2\'): ");
                                    answer = Console.ReadLine();
                                    string symbols = "abcdefghijABCDEFGHIJ";
                                    bool exitOrNot = false;

                                    if (answer != "222ADMIN222")
                                    {
                                        if (answer != null)
                                        {
                                            if (answer.Length > 1)
                                            {
                                                if (Char.IsDigit(answer[1]))
                                                {
                                                    foreach (char c in symbols)
                                                    {
                                                        if (answer[0] == c)
                                                        {
                                                            exitOrNot = true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    } else
                                    {
                                        playerWin = 2;
                                        break;
                                    }

                                    if (exitOrNot)
                                    {
                                        break;
                                    }
                                }

                                if (PlayersTurn(field1, answer))
                                {
                                    shipArray1.checkOnDeath(field1);
                                    Console.WriteLine();
                                    ShowSpace(field1, false);
                                    if (checkWin(field2) || playerWin == 2)
                                    {
                                        playerWin = 2;
                                    }
                                    break;
                                }
                                shipArray1.checkOnDeath(field1);
                                Console.WriteLine();
                                if (checkWin(field2) || playerWin == 2)
                                {
                                    playerWin = 2;
                                    break;
                                }
                            }

                            if (playerWin != 0)
                            {
                                break;
                            }

                            if (QuestionContinue("Continue (y/n): "))
                            {
                                game = false;
                                break;
                            }

                            Console.Clear();
                        }

                        if ( playerWin == 1 )
                        {
                            Console.Clear();
                            printPlayerWin(1);
                            ShowSpace(field2, false);

                            playMusic();

                            if (QuestionContinue("\nAgain (y/n): "))
                            {
                                game = false;
                                break;
                            } else
                            {
                                preGame = false;
                                break;
                            }
                        }
                        else if (playerWin == 2)
                        {
                            Console.Clear();
                            printPlayerWin(2);
                            ShowSpace(field1, false);

                            playMusic();

                            if (QuestionContinue("\nAgain (y/n): "))
                            {
                                game = false;
                                break;
                            } 
                            else
                            {
                                preGame = false;
                                break;
                            }
                        }
                        break;

                    }

                }

                field1 = field0; 
                field2 = field0;
                Console.WriteLine("\n");
                continue;
            }

        }

        static void playMusic()
        {
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(330, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(742, 500);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 250);
            Thread.Sleep(125);
            Console.Beep(352, 125);
            Thread.Sleep(125);
            Console.Beep(330, 500);
            Thread.Sleep(125);
            Console.Beep(297, 1000);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
        }

        static bool QuestionContinue(string answer)
        {
            while (true)
            {
                if (!QuestionYorN(answer))
                {
                    if (QuestionYorN("Exit (y/n): "))
                    {
                        Console.Beep(2500, 200);
                        if (QuestionYorN("Confirm exit (y/n): "))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
        }


        static bool Question( string answer )
        {
            while (true)
            {
                Console.Write(answer);
                answer = Console.ReadLine();
                if (answer == "y" || String.IsNullOrEmpty(answer) ) { return true; }
                else { continue; }
            }
        }

        static bool QuestionYorN(string answer)
        {
            while (true)
            {
                Console.Write(answer);
                answer = Console.ReadLine();
                if (answer == "y" || answer == null || String.IsNullOrEmpty(answer)) { return true; }
                else if (answer == "n") { return false; }
            }
        }


        static bool PlayersTurn( int[,] field, string coord )
        {
            int x = 0;

            switch (Char.ToString(coord[0]))
            {
                case "a":
                    x = 0;
                    break;
                case "b": 
                    x = 1;
                    break;
                case "c":
                    x = 2;
                    break;
                case "d":
                    x = 3;
                    break;
                case "e":
                    x = 4;
                    break;
                case "f":
                    x = 5;
                    break;
                case "g":
                    x = 6;
                    break;
                case "h":
                    x = 7;
                    break;
                case "i":
                    x = 8;
                    break;
                case "j":
                    x = 9;
                    break;
                case "A":
                    x = 0;
                    break;
                case "B":
                    x = 1;
                    break;
                case "C":
                    x = 2;
                    break;
                case "D":
                    x = 3;
                    break;
                case "E":
                    x = 4;
                    break;
                case "F":
                    x = 5;
                    break;
                case "G":
                    x = 6;
                    break;
                case "H":
                    x = 7;
                    break;
                case "I":
                    x = 8;
                    break;
                case "J":
                    x = 9;
                    break;
                case null:
                    x = 1;
                    break;
            }

            int y = Int16.Parse(Char.ToString(coord[1]));
            if (y == 1)
            {
                if ( coord.Length > 2 && Int16.Parse(Char.ToString(coord[2])) == 0 )
                {
                    y = 10;
                }
            }

            if ( field[y-1, x] == 8 ) {
                field[y-1, x] = 2;
                return false;
            }
            else
            {
                field[y-1, x] = 1;
                return true;
            }
        }


        static void BuilderRandom(int[,] field, int fieldNumber)
        {
            Random rnd = new Random();
            Random Random = new Random(rnd.Next(0, 10));
            int direction, x, y;
            bool canOrNot;

            void PlaceShip(int shipLength)
            {
                while (true)
                {
                    direction = Random.Next(0, 2) * 90;
                    x = Random.Next(0, 10);
                    y = Random.Next(0, 10);

                    // check on exit from field
                    canOrNot = true;
                    if (direction == 90 || direction == 0)
                    {
                        if (x < 0 || y < 0 || x + shipLength > 9 || y > 9)
                        {
                            canOrNot = false;
                            continue;
                        }
                    }

                    // check on other ships
                    if (canOrNot)
                    {
                        for (int i = x - 1; i < x + shipLength + 1; i++)
                        {
                            for (int j = y - 1; j <= y + 1; j++)
                            {
                                if (true)
                                {
                                    if (i >= 0 && j >= 0 && i < 10 && j < 10)
                                    {
                                        if (direction == 90)
                                        {
                                            if (field[j, i] == 8 || field[j, i] == 10)
                                            {
                                                canOrNot = false;
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            if (field[i, j] == 8 || field[j, i] == 10)
                                            {
                                                canOrNot = false;
                                                continue;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (canOrNot)
                    {
                        for (int i = x - 1; i < x + shipLength + 1; i++)
                        {
                            for (int j = y - 1; j <= y + 1; j++)
                            {
                                if (i >= 0 && j >= 0 && i < 10 && j < 10)
                                {
                                    if (direction == 90)
                                    {
                                        if (field[j, i] != 8) {
                                            if (j == y && i == x - 1 || j == y && i == x + shipLength || j == y - 1 || j == y + 1)
                                            {
                                                field[j, i] = -1;
                                            }
                                            else
                                            {
                                                field[j, i] = 8;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (field[i, j] != 8)
                                        {
                                            if (j == y && i == x - 1 || j == y && i == x + shipLength || j == y - 1 || j == y + 1)
                                            {
                                                field[i, j] = -1;
                                            }
                                            else
                                            {
                                                field[i, j] = 8;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        // Console.WriteLine($"{shipLength} ({x}, {y}) {direction}*");
                        break;
                    }


                }
            }

            // 4-sized ship
            PlaceShip(4);
            if (fieldNumber == 1) {
                shipArray1.array[0] = new Ship(x, y, direction, 4, fieldNumber);
            } else
            {
                shipArray2.array[0] = new Ship(x, y, direction, 4, 2);
            }

            // 3-sized ship
            PlaceShip(3);
            if (fieldNumber == 1)
            {
                shipArray1.array[1] = new Ship(x, y, direction, 3, fieldNumber);
            }
            else
            {
                shipArray2.array[1] = new Ship(x, y, direction, 3, 2);
            }
            PlaceShip(3);
            if (fieldNumber == 1)
            {
                shipArray1.array[2] = new Ship(x, y, direction, 3, fieldNumber);
            }
            else
            {
                shipArray2.array[2] = new Ship(x, y, direction, 3, 2);
            }

            // 2-sized ship
            PlaceShip(2);
            if (fieldNumber == 1)
            {
                shipArray1.array[3] = new Ship(x, y, direction, 2, fieldNumber);
            }
            else
            {
                shipArray2.array[3] = new Ship(x, y, direction, 2, 2);
            }
            PlaceShip(2);
            if (fieldNumber == 1)
            {
                shipArray1.array[4] = new Ship(x, y, direction, 2, fieldNumber);
            }
            else
            {
                shipArray2.array[4] = new Ship(x, y, direction, 2, 2);
            }
            PlaceShip(2);
            if (fieldNumber == 1)
            {
                shipArray1.array[5] = new Ship(x, y, direction, 2, fieldNumber);
            }
            else
            {
                shipArray2.array[5] = new Ship(x, y, direction, 2, 2);
            }

            // 1-sized ship
            PlaceShip(1);
            if (fieldNumber == 1)
            {
                shipArray1.array[6] = new Ship(x, y, direction, 1, fieldNumber);
            }
            else
            {
                shipArray2.array[6] = new Ship(x, y, direction, 1, 2);
            }
            PlaceShip(1);
            if (fieldNumber == 1)
            {
                shipArray1.array[7] = new Ship(x, y, direction, 1, fieldNumber);
            }
            else
            {
                shipArray2.array[7] = new Ship(x, y, direction, 1, 2);
            }
            PlaceShip(1);
            if (fieldNumber == 1)
            {
                shipArray1.array[8] = new Ship(x, y, direction, 1, fieldNumber);
            }
            else
            {
                shipArray2.array[8] = new Ship(x, y, direction, 1, 2);
            }
            PlaceShip(1);
            if (fieldNumber == 1)
            {
                shipArray1.array[9] = new Ship(x, y, direction, 1, fieldNumber);
            }
            else
            {
                shipArray2.array[9] = new Ship(x, y, direction, 1, 2);
            }
        }


        static bool checkWin(int[,] field)
        {
            int total = 20;
            int alive = 0;
            foreach ( int cell in field )
            {
                if ( cell == 8 )
                {
                    alive++;
                }
            }
            if (alive == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void printPlayerWin(int player)
        {
            //  ___     ____  _                                         _
            // |_  |   | ,_ \| |   __ _ _    _  ___  _ __   _    _    _|_|_ ___  ___
            //   | |   |  __/| |  / _` | |  | |/ _ \| `__| | |  | |  | | | `_  \/ __|
            //  _| |_  | |   | |_| (_| | |__| |  __/| |     \ \/ | \/ /| | | | |\__ \
            // |_____| |_|   \___|\__,_|\___  |\___||_|      \__/ \__/ |_|_| |_||___/ 
            //                           ___| |
            //                          |____/
            //   ___    ____  _                                         _
            //  |__ \  | ,_ \| |   __ _ _    _  ___  _ __   _    _    _|_|_ ___  ___
            //  / __/  |  __/| |  / _` | |  | |/ _ \| `__| | |  | |  | | | `_  \/ __|
            // / /__   | |   | |_| (_| | |__| |  __/| |     \ \/ | \/ /| | | | |\__ \
            // |____|  |_|   \___|\__,_|\___  |\___||_|      \__/ \__/ |_|_| |_||___/ 
            //                           ___| |
            //                          |____/
            //  ____                ____        _   _   _        
            // / ___|  ___   __ _  | ,_ )  __ _| |_| |_| |   ___ 
            // \___ \ / _ \ / _` | |  _ \ / _` |  _|  _| |  / _ \
            //  ___) |  __/| (_| | | |_) | (_| | |_| |_| |_|  __/
            // |____/ \___| \__,_| |____/ \__,_|\__|\__|\__|\___|
            if ( player == 1 )
            {
                Console.WriteLine(" ___     ____  _                                         _");
                Console.WriteLine("|_  |   | ,_ \\| |   __ _ _    _  ___  _ __   _    _    _|_|_ ___  ___");
                Console.WriteLine("  | |   |  __/| |  / _` | |  | |/ _ \\| `__| | |  | |  | | | `_  \\/ __|");
                Console.WriteLine(" _| |_  | |   | |_| (_| | |__| |  __/| |     \\ \\/ | \\/ /| | | | |\\__ \\");
                Console.WriteLine("|_____| |_|   \\___|\\__,_|\\___  |\\___||_|      \\__/ \\__/ |_|_| |_||___/");
                Console.WriteLine("                          ___| |");
                Console.WriteLine("                         |____/");
            }
            if ( player == 2 )
            {
                Console.WriteLine("  ___    ____  _                                         _");
                Console.WriteLine(" |__ \\  | ,_ \\| |   __ _ _    _  ___  _ __   _    _    _|_|_ ___  ___");
                Console.WriteLine("  / __/ |  __/| |  / _` | |  | |/ _ \\| `__| | |  | |  | | | `_  \\/ __|");
                Console.WriteLine(" / /__  | |   | |_| (_| | |__| |  __/| |     \\ \\/ | \\/ /| | | | |\\__ \\");
                Console.WriteLine("|____|  |_|   \\___|\\__,_|\\___  |\\___||_|      \\__/ \\__/ |_|_| |_||___/");
                Console.WriteLine("                          ___| |");
                Console.WriteLine("                         |____/");
            }
        }


        static void printNewSign( string version )
        {
            //       _/_/_/
            //    _/
            //     _/_/    _/
            //        _/  _/
            // _/_/_/      _/

            //  ____                ____        _   _   _        
            // / ___|  ___   __ _  | ,_ )  __ _| |_| |_| |   ___ 
            // \___ \ / _ \ / _` | |  _ \ / _` |  _|  _| |  / _ \
            //  ___) |  __/| (_| | | |_) | (_| | |_| |_| |_|  __/
            // |____/ \___| \__,_| |____/ \__,_|\__|\__|\__|\___|
            Console.WriteLine(" ____                ____        _   _   _        ");
            Console.WriteLine("/ ___|  ___   __ _  | ,_ )  __ _| |_| |_| |   ___ ");
            Console.WriteLine("\\___ \\ / _ \\ / _` | |  _ \\ / _` |  _|  _| |  / _ \\");
            Console.WriteLine(" ___) |  __/| (_| | | |_) | (_| | |_| |_| |_|  __/");
            Console.WriteLine("|____/ \\___| \\__,_| |____/ \\__,_|\\__|\\__|\\__|\\___|");
            Console.WriteLine($"                                  Sea Battle v{version}\n");
            Console.WriteLine("A game by: ");
            Console.WriteLine("- @VicKyland");
            Console.WriteLine("- @demfed228");
            Console.WriteLine();
        }


        static void printSign()
        {
            Console.WriteLine("  ____  ____     _     ____   ");
            Console.WriteLine("  |     |       / \\    |   \\  ");
            Console.WriteLine("  |___  |___   |   |   |___/  ");
            Console.WriteLine("     |  |      |___|   |   \\  ");
            Console.WriteLine("  ___|  |___   |   |   |___/  ");
        }

        public static int map(int value, int fromLow, int fromHigh, int toLow, int toHigh)
        {
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }


        static void ShowSpace(int[,] field, bool admin)
        {
            int countOfElements = 0;
            string symbols = "×※▢■▣□⋅";
            string empty = "*";
            string barriers = "+";
            string hitShip = "■";
            string showShip = "■";
            string hit = "0";

            Console.WriteLine("A B C D E F G H I J ");
            countOfElements = 1;
            foreach (int square in field)
            {
                if (true)
                {
                    switch (square)
                    {
                        case 0:
                            Console.Write($"{empty} ");
                            break;
                        case -1:
                            if (admin) { Console.Write($"{empty} "); }
                            else { Console.Write($"{empty} "); }
                            break;
                        case 1:
                            Console.Write($"{hit} ");
                            break;
                        case 2:
                            Console.Write($"{hitShip} ");
                            break;
                        case 8:
                            if (admin) { Console.Write($"{showShip} "); }
                            else { Console.Write($"{empty} "); }
                            break;
                        case 10:
                            Console.Write($"{"&"} ");
                            break;
                    }
                    if (countOfElements % 10 == 0 || countOfElements == 0)
                    {
                        Console.WriteLine($"{countOfElements / 10} ");
                    }
                }
                countOfElements++;
            }
            // Console.WriteLine($"\n{countOfElements}");
        }
    }
}