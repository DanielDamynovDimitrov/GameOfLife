using GameOfLife.Extensions;
using GameOfLife.Models;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            new Board(width: 4, height: 4).GenerateDeadRows()
                                          .SetLiveCell(0, 1)
                                          .SetLiveCell(1, 0)
                                          .SetLiveCell(1, 1)
                                          .SetLiveCell(1, 2)
                                          .Simulate();
        }
    }
}
