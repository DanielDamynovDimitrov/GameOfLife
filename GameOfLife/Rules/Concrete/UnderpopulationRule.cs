using GameOfLife.Constants;
using GameOfLife.Extensions;
using GameOfLife.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Rules
{
    public class UnderpopulationRule : ILifeRule
    {
        /// <summary>
        /// Making cell to be dead if its being live, but has less than 2 live neighbours
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="neighbours"></param>
        public void Apply(Cell cell, List<Cell> neighbours)
        {
            int liveNeighbours = neighbours.Where(neightbour => neightbour.IsAlive)
                                           .Count();

            if (cell.IsAlive && liveNeighbours < LifeConstants.MIN_NUMBER_LIVE_NEIGHBOURS)
            {
                cell.Kill();
            }
        }
    }
}
