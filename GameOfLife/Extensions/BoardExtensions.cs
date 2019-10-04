using GameOfLife.Constants;
using GameOfLife.Models;
using System;
using System.Linq;
using System.Threading;

namespace GameOfLife.Extensions
{
    public static class BoardExtensions
    {
        /// <summary>
        /// Seting live cell from the board
        /// </summary>
        /// <param name="board"></param>
        /// <param name="rowIndex">Row where cell is positioned</param>
        /// <param name="columnIndex">Cell position in the row</param>
        /// <returns></returns>
        public static Board SetLiveCell(this Board board, int rowIndex, int columnIndex)
        {
            if (rowIndex < 0 ||
                rowIndex >= board.Rows.Count ||
                columnIndex < 0 ||
                columnIndex >= board.Rows.First().Cells.Count)
                throw new ArgumentException($"Cell with row index# {rowIndex} and column index# {columnIndex} is not existing. ");

            var cell = board[rowIndex, columnIndex];
            cell.Value = CellConstants.LIVE_CELL;
            return board;
        }

        /// <summary>
        /// Generating board with dead rows
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static Board GenerateDeadRows(this Board board)
        {
            if (board.Width <= 0 || board.Height <= 0)
                throw new ArgumentException("Width and height parameters are not correct! ");

            for (int rowIndex = 0; rowIndex < board.Height; rowIndex++)
            {
                var newRow = new Row();
                for (int columnIndex = 0; columnIndex < board.Width; columnIndex++)
                {
                    newRow.Cells.Add(new Cell(CellConstants.DEAD_CELL, rowIndex, columnIndex));
                }

                board.Rows.Add(newRow);
            }

            return board;
        }

        /// <summary>
        /// Printing board to the console
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static Board Print(this Board board)
        {
            Thread.Sleep(new TimeSpan(0, 0, LifeConstants.TIMEOUT_IN_SECONDS));
            Console.Clear();
            Console.WriteLine(board);

            return board;
        }

        public static void Simulate(this Board board)
        {
            // Initial board print
            board.Print();
            bool boardStateChanged = true;

            while (boardStateChanged)
            {
                boardStateChanged = false;
                foreach (var row in board.Rows)
                {
                    foreach (var cell in row.Cells)
                    {
                        bool isCellStateChanged = cell.TrySettingNewState(board);
                        if (isCellStateChanged)
                            boardStateChanged = isCellStateChanged;
                    }
                }

                board.Print();
            }
        }

        /// <summary>
        /// Try getting cell from the board based on the provided coordinates
        /// </summary>
        /// <param name="board"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <returns>Cell from the board or null if cell is not existing.</returns>
        public static Cell TryGetCell(this Board board, int rowIndex, int columnIndex)
        {
            // Not existing row index
            if (rowIndex < 0 || rowIndex >= board.Rows.Count)
                return null;

            // Not existing column index
            if (columnIndex < 0 || columnIndex >= board.Rows.First().Cells.Count)
                return null;

            return board[rowIndex, columnIndex];
        }
    }
}
