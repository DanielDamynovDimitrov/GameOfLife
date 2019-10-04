using GameOfLife.Models;

namespace GameOfLife.Rules.Contracts
{
    public interface ILiveRuleService
    {
        void ApplyRules(Board board, Cell cell);
    }
}
