using GameOfLife.Models;
using System.Collections.Generic;

namespace GameOfLife.Rules
{
    public interface ILifeRule
    {
        void Apply(Cell cell, List<Cell> neighbours);
    }
}
