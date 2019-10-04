using GameOfLife.Extensions;
using GameOfLife.Models;
using GameOfLife.Rules.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Rules
{
    public class LiveRuleService
    {
        private static volatile LiveRuleService ruleService = null;
        private readonly IReadOnlyCollection<ILifeRule> _rules = new List<ILifeRule>()
        {
            new LiveRule(),
            new OverPopulationRule(),
            new UnderpopulationRule()
        };

        private LiveRuleService()
        { }

        public static LiveRuleService Instance
        {
            get
            {
                if (ruleService == null)
                    ruleService = new LiveRuleService();

                return ruleService;
            }
        }

        public bool ApplyRules(Board board, Cell cell)
        {
            var initialState = cell.Value;
            var neightbours = cell.GetNeighbours(board)
                                  .ToList();

            foreach (var rule in this._rules)
            {
                rule.Apply(cell, neightbours);
            }

            return initialState != cell.Value;
        }
    }
}
