using System;
using static System.Console;
using static System.Convert;
namespace fone_3._3
{
    class Program
    {
        public static int Height;
        public static int Width;

        static void Main(string[] args)
        {
            Write("Высота: ");
            Height = ToInt32(ReadLine());
            Write("Ширина: ");
            Width = ToInt32(ReadLine());
            int[,] board = new int[Height, Width];
            Position pos = new Position(4, 0);
            WriteLine("Доска вводится сверху вниз");
            for (int i = 0; i < Height; i++)
            {
                WriteLine("Введите ряд номер {0}:", i + 1);
                string str = ReadLine();
                string[] row = str.Split(" ");
                for (int j = 0; j < Width; j++)
                {
                    board[i, j] = ToInt32(row[j]);
                }
            } //ввод
            WriteLine("Ваша доска: ");
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    switch (board[i, j])
                    {
                        case 0:
                            ForegroundColor = ConsoleColor.Black;
                            break;
                        case 1:
                            ForegroundColor = ConsoleColor.White;
                            break;
                        case 2:
                            ForegroundColor = ConsoleColor.Red;
                            pos.h = i;
                            pos.w = j;
                            break;
                    }
                    Write(board[i, j]);
                }
                ResetColor();
                WriteLine("");
            } //вывод (цветастый :з)
            WriteLine("Максимум можно съесть {0} шашек(шашки)", BestJob(board, pos));
        }

        static int BestJob(int[,] inputBoard, Position inputPos)
        {
            int max = 0;
            if (CanIDoThat(inputBoard, inputPos, 1))
            {
                if (max == 0) max = 1;
                int[,] outputBoard = (int[,])inputBoard.Clone();
                Position outputPos = inputPos;
                outputPos.h -= 2;
                outputPos.w -= 2;
                outputBoard[inputPos.h, inputPos.w] = 0;
                outputBoard[inputPos.h - 1, inputPos.w - 1] = 0;
                outputBoard[inputPos.h - 2, inputPos.w - 2] = 2;
                max += BestJob(outputBoard, outputPos);
            }
            if (CanIDoThat(inputBoard, inputPos, 2))
            {
                if (max == 0) max = 1;
                int[,] outputBoard = (int[,])inputBoard.Clone();
                Position outputPos = inputPos;
                outputPos.h -= 2;
                outputPos.w += 2;
                outputBoard[inputPos.h, inputPos.w] = 0;
                outputBoard[inputPos.h - 1, inputPos.w + 1] = 0;
                outputBoard[inputPos.h - 2, inputPos.w + 2] = 2;
                int max1 = BestJob(outputBoard, outputPos) + 1;
                if (max < max1) max = max1;
            }
            if (CanIDoThat(inputBoard, inputPos, 3))
            {
                if (max == 0) max = 1;
                int[,] outputBoard = (int[,])inputBoard.Clone();
                Position outputPos = inputPos;
                outputPos.h += 2;
                outputPos.w -= 2;
                outputBoard[inputPos.h, inputPos.w] = 0;
                outputBoard[inputPos.h + 1, inputPos.w - 1] = 0;
                outputBoard[inputPos.h + 2, inputPos.w - 2] = 2;
                int max1 = BestJob(outputBoard, outputPos) + 1;
                if (max < max1) max = max1;
            }
            if (CanIDoThat(inputBoard, inputPos, 4))
            {
                if (max == 0) max = 1;
                int[,] outputBoard = (int[,])inputBoard.Clone();
                Position outputPos = inputPos;
                outputPos.h += 2;
                outputPos.w += 2;
                outputBoard[inputPos.h, inputPos.w] = 0;
                outputBoard[inputPos.h + 1, inputPos.w + 1] = 0;
                outputBoard[inputPos.h + 2, inputPos.w + 2] = 2;
                int max1 = BestJob(outputBoard, outputPos) + 1;
                if (max < max1) max = max1;
            }
            return max;
        }
        /*
           1         2
               шаш
               ка
           3        4
        */
        static bool CanIDoThat(int[,] board, Position pos, int posToEat)
        {
            switch (posToEat)
            {
                case 1:
                    if (pos.h - 2 < 0 || pos.w - 2 < 0) return false;
                    if (pos.h - 1 <= 0 || pos.w - 1 <= 0) return false;
                    if (board[pos.h - 1, pos.w - 1] == 1 && board[pos.h - 2, pos.w - 2] == 0) return true;
                    return false;
                case 2:
                    if (pos.h - 2 < 0 || pos.w + 2 > Width - 1) return false;
                    if (pos.h - 1 <= 0 || pos.w + 1 >= Width - 1) return false;
                    if (board[pos.h - 1, pos.w + 1] == 1 && board[pos.h - 2, pos.w + 2] == 0) return true;
                    return false;
                case 3:
                    if (pos.h + 2 > Height - 1 || pos.w - 2 < 0) return false;
                    if (pos.h + 1 >= Height - 1 || pos.w - 1 <= 0) return false;
                    if (board[pos.h + 1, pos.w - 1] == 1 && board[pos.h + 2, pos.w - 2] == 0) return true;
                    return false;
                case 4:
                    if (pos.h + 2 > Height - 1 || pos.w + 2 > Width - 1) return false;
                    if (pos.h + 1 >= Height - 1 || pos.w + 1 >= Width - 1) return false;
                    if (board[pos.h + 1, pos.w + 1] == 1 && board[pos.h + 2, pos.w + 2] == 0) return true;
                    return false;
            }
            return false;
        }
        struct Position
        {
            public int h;
            public int w;
            public Position(int h, int w)
            {
                this.h = h;
                this.w = w;
            }
        }
    }
}