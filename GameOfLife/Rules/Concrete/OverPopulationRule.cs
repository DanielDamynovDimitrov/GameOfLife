using GameOfLife.Constants;
using GameOfLife.Extensions;
using GameOfLife.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Rules
{
    public class OverPopulationRule : ILifeRule
    {
        /// <summary>
        /// Making cell to dead if its being live but has more than 3 live  neighbours
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="neighbours"></param>
        public void Apply(Cell cell, List<Cell> neighbours)
        {
            int liveNeighbours = neighbours.Where(neightbour => neightbour.IsAlive)
                                           .Count();

            if (cell.IsAlive && liveNeighbours > LifeConstants.MAX_NUMBER_LIVE_NEIGHBOURS)
            {
                cell.Kill();
            }
        }
    }
}
