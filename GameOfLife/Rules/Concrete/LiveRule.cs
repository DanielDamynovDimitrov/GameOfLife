using GameOfLife.Constants;
using GameOfLife.Extensions;
using GameOfLife.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Rules
{
    public class LiveRule : ILifeRule
    {
        /// <summary>
        /// Making cell to be a live if its being dead and has 3 live neighbours
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="neighbours"></param>
        public void Apply(Cell cell, List<Cell> neighbours)
        {
            int liveNeighbours = neighbours.Where(neightbour => neightbour.IsAlive)
                                           .Count();

            if (cell.IsDead && liveNeighbours == LifeConstants.MAX_NUMBER_LIVE_NEIGHBOURS)
            {
                cell.DoLive();
            }
        }
    }
}
