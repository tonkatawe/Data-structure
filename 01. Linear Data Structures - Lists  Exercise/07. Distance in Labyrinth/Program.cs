using System;
using System.Collections.Generic;

namespace _07._Distance_in_Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var matrix = new string[size, size];
            //make the same size bool matrix
            var visited = new bool[size, size];

            var row = 0;
            var col = 0;
            //Read the matrix
            for (var matrixRow = 0; matrixRow < matrix.GetLength(0); matrixRow++)
            {
                var currentRowInMatrix = Console.ReadLine()
                    .ToCharArray();

                for (var matrixCol = 0; matrixCol < matrix.GetLength(1); matrixCol++)
                {
                    matrix[matrixRow, matrixCol] = currentRowInMatrix[matrixCol].ToString();
                    if (currentRowInMatrix[matrixCol] == '*')
                    {
                        row = matrixRow;
                        col = matrixCol;
                    }
                }
            }


            var checker = new Queue<Cell>();
            checker.Enqueue(new Cell(row, col, false, 0));

            while (checker.Count != 0)
            {
                //take currentCell
                var currentCell = checker.Dequeue();
                row = currentCell.Row;
                col = currentCell.Col;

                currentCell.Visited = true;
                visited[row, col] = true;
                if (matrix[row, col] != "*")
                {

                    matrix[row, col] = currentCell.Moves.ToString();
                }

                //move up
                if (row - 1 >= 0 && matrix[row - 1, col] != "x" && !visited[row - 1, col])
                {
                    checker.Enqueue(new Cell(row - 1, col, false, currentCell.Moves + 1));
                }
                //move down
                if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] != "x" && !visited[row + 1, col])
                {
                    checker.Enqueue(new Cell(row + 1, col, false, currentCell.Moves + 1));
                }
                //move right
                if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] != "x" && !visited[row, col + 1])
                {
                    checker.Enqueue(new Cell(row, col + 1, false, currentCell.Moves + 1));
                }
                //move left
                if (col - 1 >= 0 && matrix[row, col - 1] != "x" && !visited[row, col - 1])
                {
                    checker.Enqueue(new Cell(row, col - 1, false, currentCell.Moves + 1));
                }
            }

            PrintMatrix(matrix);


        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        Console.Write("u");
                    }
                    else
                    {
                        Console.Write(matrix[i, j]);
                    }
                }

                Console.WriteLine();
            }
        }

        //Use this class for check cells in matrix
        private class Cell
        {
            public Cell(int row, int col, bool visited, int moves)
            {
                this.Row = row;
                this.Col = col;
                this.Visited = visited;
                this.Moves = moves;
            }
            public int Row { get; set; }
            public int Col { get; set; }
            public bool Visited { get; set; }
            public int Moves { get; set; }
        }
    }
}
