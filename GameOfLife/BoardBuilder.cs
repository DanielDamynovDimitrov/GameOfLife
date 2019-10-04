using GameOfLife.Extensions;
using GameOfLife.Models;

namespace GameOfLife
{
    public class BoardBuilder
    {
        private static Board _board;

        public static Board GetBoard(int width, int height)
        {
            _board = new Board(width, height);
            _board.GenerateLiveCells();

            return _board;
        }
    }
}
