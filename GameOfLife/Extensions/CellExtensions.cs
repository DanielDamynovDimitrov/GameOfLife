using GameOfLife.Models;
using GameOfLife.Rules;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Extensions
{
    public static class CellExtensions
    {
        /// <summary>
        /// Applying game of life rules to a specific board cell
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="board"></param>
        /// <returns>If cell state has changed. </returns>
        public static bool TrySettingNewState(this Cell cell, Board board)
            => LiveRuleService.Instance.ApplyRules(board, cell);

        /// <summary>
        /// Get neighbours of a specific board cell
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public static IList<Cell> GetNeighbours(this Cell cell, Board board)
            => new List<Cell>()
            {
                board.TryGetCell(cell.RowPosition, cell.ColumnPosition - 1),
                board.TryGetCell(cell.RowPosition, cell.ColumnPosition + 1),
                board.TryGetCell(cell.RowPosition - 1, cell.ColumnPosition),
                board.TryGetCell(cell.RowPosition + 1, cell.ColumnPosition),
                board.TryGetCell(cell.RowPosition - 1, cell.ColumnPosition - 1),
                board.TryGetCell(cell.RowPosition - 1, cell.ColumnPosition + 1),
                board.TryGetCell(cell.RowPosition + 1, cell.ColumnPosition - 1),
                board.TryGetCell(cell.RowPosition + 1, cell.ColumnPosition + 1),
            }
            .Where(neighBourCell => neighBourCell.IsValid())
            .ToList();

        /// <summary>
        /// Killing cell
        /// </summary>
        /// <param name="cell"></param>
        public static void Kill(this Cell cell) => cell.Value = CellConstants.DEAD_CELL;

        /// <summary>
        /// Do cell being live
        /// </summary>
        /// <param name="cell"></param>
        public static void DoLive(this Cell cell) => cell.Value = CellConstants.LIVE_CELL;

        /// <summary>
        /// Check if cell is not null
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static bool IsValid(this Cell cell) => cell != null;
    }
}
