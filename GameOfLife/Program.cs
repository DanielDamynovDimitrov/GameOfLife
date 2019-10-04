using GameOfLife.Extensions;
using GameOfLife.Models;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            new Board(width: 5, height: 5).GenerateDeadRows()
                                          .SetLiveCell(1, 2)
                                          .SetLiveCell(2, 2)
                                          .SetLiveCell(3, 2)
                                          .Simulate();
        }
    }
}
