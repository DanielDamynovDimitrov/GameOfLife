namespace GameOfLife.Models
{
    public class Cell
    {
        public int RowPosition { get; private set; }

        public int ColumnPosition { get; private set; }

        public string Value { get; set; }

        /// <summary>
        /// This is needed because when checking if cell should live or die depending on neighbours, we have to take care of the current iteration initial cells state.
        /// </summary>
        public string NewValue { get; set; }

        public bool IsAlive => this.Value == CellConstants.LIVE_CELL;

        public bool IsDead => this.Value == CellConstants.DEAD_CELL;

        public Cell(string value, int rowPosition, int columnPosition)
        {
            this.Value = value;
            this.NewValue = this.Value;
            this.RowPosition = rowPosition;
            this.ColumnPosition = columnPosition;
        }

        public override string ToString() => this.Value.ToString();
    }
}
