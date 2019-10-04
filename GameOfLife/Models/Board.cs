using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Models
{
    public class Board
    {
        public IList<Row> Rows { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Board(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            this.Rows = new List<Row>();
        }

        /// <summary>
        /// Printing board content
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var boardStringBuilder = new StringBuilder();
            foreach (Row row in this.Rows)
            {
                boardStringBuilder.AppendLine(row.ToString());
            }

            return boardStringBuilder.ToString();
        }

        /// <summary>
        /// Index for accessing cell on the board
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="cellIndex"></param>
        /// <returns></returns>
        public Cell this[int rowIndex, int cellIndex] => this.Rows[rowIndex][cellIndex];
    }
}
