using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp
{
    public class SudokuSolver
    {
        private readonly int[,] board; //Sudoku Board

        public SudokuSolver(int[,] initialBoard)
        {
            //Class instance initialization with board
            this.board = (int[,])initialBoard.Clone(); //Copy of initial board
        }

        //Sudoku solving method
        public bool Solve()
        {

            //Finding first empty cell in grid
            if (!FindEmptyLocation(out int row, out int col))
                return true; //No empty space = Sudoku solved

            //Attempt to place a number into the empty cell, recursive calling Solve()
            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(row, col, num))
                {
                    board[row, col] = num; //Place number into the cell

                    //Recursively calling Solve()
                    if (Solve())
                        return true;

                    board[row, col] = 0; //Backtracking - if there is no solution, set solution to 0
                }
            }

            return false; //No solution found - return false
        }

        //Finding first empty cell in the grid
        private bool FindEmptyLocation(out int row, out int col)
        {
            for (row = 0; row < 9; row++)
            {
                for (col = 0; col < 9; col++)
                {
                    if (board[row, col] == 0)
                        return true; //If empty cell is found return true
                }
            }
            row = -1;
            col = -1;
            return false; //No empty cell - return false
        }

        //Checking if number is already used in a row
        private bool UsedInRow(int row, int num)
        {
            for (int col = 0; col < 9; col++)
            {
                if (board[row, col] == num)
                    return true;
            }
            return false;
        }

        //Checking if number is already used in column
        private bool UsedInColumn(int col, int num)
        {
            for (int row = 0; row < 9; row++)
            {
                if (board[row, col] == num)
                    return true;
            }
            return false;
        }

        //Checking if number is already used in 3x3 box
        private bool UsedInBox(int boxStartRow, int boxStartCol, int num)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row + boxStartRow, col + boxStartCol] == num)
                        return true;
                }
            }
            return false;
        }

        //Check if its safe to place number into to position in the grid
        private bool IsSafe(int row, int col, int num)
        {
            return !UsedInRow(row, num) && !UsedInColumn(col, num) && !UsedInBox(row - row % 3, col - col % 3, num);
        }

        //Getting the solution 
        public int[,] GetSolution()
        {
            int[,] solution = new int[9, 9]; //Creating field for solution
            Array.Copy(board, solution, board.Length); //Creating copy of solution
            return solution; //Return solution
        }
    }
}
