using GameOfLife.Extensions;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardBuilder.GetBoard(5, 5)
                        .SetDieCell(1, 2)
                        .SetDieCell(2, 2)
                        .SetDieCell(3, 2)
                        .Simulate();
        }
    }
}
