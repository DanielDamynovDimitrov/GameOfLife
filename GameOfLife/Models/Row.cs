using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Models
{
    public class Row
    {
        public IList<Cell> Cells { get; private set; }

        public Row()
        {
            this.Cells = new List<Cell>();
        }

        public Row(List<Cell> cells)
        {
            this.Cells = cells;
        }

        /// <summary>
        /// Printing row content
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var rowStringBuilder = new StringBuilder();
            foreach (var cell in this.Cells)
            {
                rowStringBuilder.Append(cell.ToString());
            }

            return rowStringBuilder.ToString();
        }

        /// <summary>
        /// Index for accessing cell from the row
        /// </summary>
        /// <param name="cellIndex"></param>
        /// <returns></returns>
        public Cell this[int cellIndex] => this.Cells[cellIndex];
    }
}
