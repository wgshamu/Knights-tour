using System;
using System.Collections.Generic;

namespace ConsoleApp7
{
    class Position
    {
        public List<Position> Movelist = new List<Position>();
        public int nextTry = 0;
        public int x;
        public int y;
        public bool[] booly = new bool[8];
        
        public Position(int xl, int yl)
        {
            x = xl;
            y = yl;
        }
        public Position Move(int direction, int[,] board)
        {
            if (booly[direction] == true)
            {
                return null;
            }
            booly[direction] = true;
            int newx = x;
            int newy = y;
            switch (direction)
            {
                case 0:
                    newx += 2;
                    newy += 1;
                    break;
                case 1:
                    newx += 1;
                    newy += 2;
                    break;
                case 2:
                    newx -= 2;
                    newy += 1;
                    break;
                case 3:
                    newx -= 1;
                    newy += 2;
                    break;
                case 4:
                    newx += 2;
                    newy -= 1;
                    break;
                case 5:
                    newx += 1;
                    newy -= 2;
                    break;
                case 6:
                    newx -= 2;
                    newy -= 1;
                    break;
                case 7:
                    newx -= 1;
                    newy -= 2;
                    break;

            }
            if (newx >= 8 || newy >= 8 || newx < 0 || newy < 0)
                return null;
            else if (board[newx, newy] != 0)
                return null;
            else
                return new Position(newx, newy);



        }
        public Position moveList(int octet, int[,] board)
        {

            int newx = x;
            int newy = y;
            switch (octet)
            {
                case 0:
                    newx += 2;
                    newy += 1;
                    break;
                case 1:
                    newx += 1;
                    newy += 2;
                    break;
                case 2:
                    newx -= 2;
                    newy += 1;
                    break;
                case 3:
                    newx -= 1;
                    newy += 2;
                    break;
                case 4:
                    newx += 2;
                    newy -= 1;
                    break;
                case 5:
                    newx += 1;
                    newy -= 2;
                    break;
                case 6:
                    newx -= 2;
                    newy -= 1;
                    break;
                case 7:
                    newx -= 1;
                    newy -= 2;
                    break;

            }
            if (newx >= 8 || newy >= 8 || newx < 0 || newy < 0)
            {
               
             /*  if (Program.board[3, 3] != 0)
                {
                    Console.WriteLine(octet);
                } */
                return new Position(0, 0);
            }
            else if (board[newx, newy] != 0) {

                /*if (Program.board[3, 3] != 0 && octet == 2)
            {
                Console.WriteLine(octet * -1);
            } */
                return new Position(0, 0);
            }
            else
             //   Console.Write(newx);
         //   Console.WriteLine(newy);

                return new Position(newx, newy);

        }
        public int nextDetect(Position TempMove, int[,] board)
        {
            int DetectedMoves = 0;
            //Console.Write(TempMove.x);
           // Console.Write(", ");
           // Console.WriteLine(TempMove.y);
            for (int g = 0; g < 8; g++)
            {
                int newx = TempMove.x;
                int newy = TempMove.y;

                switch (g)
                {

                    case 0:
                        newx += 2;
                        newy += 1;
                        break;
                    case 1:
                        newx += 1;
                        newy += 2;
                        break;
                    case 2:
                        newx -= 2;
                        newy += 1;
                        break;
                    case 3:
                        newx -= 1;
                        newy += 2;
                        break;
                    case 4:
                        newx += 2;
                        newy -= 1;
                        break;
                    case 5:
                        newx += 1;
                        newy -= 2;
                        break;
                    case 6:
                        newx -= 2;
                        newy -= 1;
                        break;
                    case 7:
                        newx -= 1;
                        newy -= 2;
                        break;
                }

                if (newx >= 8 || newy >= 8 || newx < 0 || newy < 0)
                { }


                else if (board[newx, newy] == 0)
                {
                 // Console.Write($"Board at {newx}, {newy} = {board[newx, newy]}  ");
                    DetectedMoves++;
                }
            }
           // Console.WriteLine($" {DetectedMoves} is detected");
            return DetectedMoves;
        }
        public bool truly()
        {
            for (int c = 0; c < 8; c++)
            {
                if (booly[c] == false)
                    return false;

            }
            return true;
        }

        public int NextDirect()
        {
            int tempTry = nextTry;
            for (int b = 1; b < 8; b++)
            {
                for (int t = 0; t < 8; t++)
                {
                    if (Movelist[t].x != Program.start.x || Movelist[t].y != Program.start.y)
                    {
                        Position TempMove = new Position(Movelist[t].x, Movelist[t].y);
                        if (TempMove.nextDetect(TempMove, Program.board) == b)
                        {
                            if (tempTry == 0)
                                return t;
                            else
                            {
                                tempTry--;

                            }


                        }
                    }
                }
            }
           
                return -1;

        }
    }

    class Program
    {

        public static int status = 0;
        static Random land = new Random();
        public static int[,] board = new int[8, 8];
        public static List<Position> Moves = new List<Position>();
       
        public static Position start = new Position(0, 0);
        static void Main()
        {
            
             var starttoo = new Position(1, 2);
            board[0, 0] = 1;
            board[1, 2] = 2;
            Moves.Add(start);
            Moves.Add(starttoo);
          
            while (true)
                
            {
                var lastMove = Moves[Moves.Count - 1];
               lastMove.Movelist.Clear();
                
                if (lastMove.truly() == true)
                {
                    Moves.Remove(lastMove);
                    board[lastMove.x, lastMove.y] = 0;
                    printBoard();
                }
                for (int octet = 0; octet < 8; octet++)

                {
                    var Movel = lastMove.moveList(octet, board);
                    lastMove.Movelist.Add(Movel);
                }
                recourse(lastMove);
                
            }
        }
        static void printBoard()
        {
            Console.WriteLine("");
            for (int i = 0; i < 8; i++)
            {
                
                for (int z = 0; z < 8; z++)
                {
                    Console.Write($"{board[i, z]:00}, ");

                }
                Console.WriteLine("");

            }

        }
        
        static void recourse(Position lastMove)
        {
            //Console.Write($"{lastMove.nextTry}, nextTry Counter ");
            int direction = lastMove.NextDirect();
           // Console.WriteLine(direction);
            if (direction == -1 && lastMove.nextTry == 0)
            {
                
                Moves.Remove(lastMove);
                board[lastMove.x, lastMove.y] = 0;
                printBoard();
                lastMove = Moves[Moves.Count - 1];
                lastMove.nextTry += 1;
               // Console.Write("increment ");
                recourse(lastMove);
            }
            else if (lastMove.nextTry >= 8)
            {
               // Console.Write($"bug305 {lastMove.x}");
               
                Moves.Remove(lastMove);
                board[lastMove.x, lastMove.y] = 0;
                printBoard();
                lastMove = Moves[Moves.Count - 1];
                lastMove.nextTry += 1;
               // Console.Write("increment");
                recourse(lastMove);


            }
            else if (direction == -1 && lastMove.nextTry != 0)
            {
                lastMove.nextTry += 1;
                //Console.Write("bug 309");
                recourse(lastMove);
                
            }
            
            else
            {
                //Console.Write($"Adding NextMove { direction} ");
                var nextMove = lastMove.Move(direction, board);
                if (nextMove == null)
                {
                    nextMove = lastMove.Move(direction, board);
                }
                    Moves.Add(nextMove);


                board[nextMove.x, nextMove.y] = Moves.Count;
                    printBoard();
                if (Moves.Count > status)
                    status = Moves.Count;
                Console.WriteLine($"Maximum count is {status}!");
                if (board[nextMove.x, nextMove.y] == 63) 
                System.Diagnostics.Debugger.Break();
             

            }
        }
      

    }
}
