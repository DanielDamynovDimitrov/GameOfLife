using FluentAssertions;
using GameOfLife.Extensions;
using GameOfLife.Models;
using GameOfLife.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LiveCell_WithUnderPopulation_Should_Die()
        {
            Board board = new Board(2, 2)
                .GenerateDeadRows()
                .SetLiveCell(0, 0);
            var cell = board.TryGetCell(0, 0);
            cell.IsAlive.Should().BeTrue();

            // This should make it die because it has 3 died neighbours
            bool isChanged = LiveRuleService.Instance.ApplyRules(board, cell);
            isChanged.Should().BeTrue();
            cell.IsDead.Should().BeTrue();
        }

        [TestMethod]
        public void LiveCell_WithThreeLive_Should_Go_To_NextGeneration()
        {
            Board board = new Board(2, 2)
                .GenerateDeadRows()
                .SetLiveCell(0, 0)
                .SetLiveCell(0, 1)
                .SetLiveCell(1, 0)
                .SetLiveCell(1, 1);

            var cell = board.TryGetCell(0, 0);
            cell.IsAlive.Should().BeTrue();

            bool isChanged = LiveRuleService.Instance.ApplyRules(board, cell);
            isChanged.Should().BeFalse();
            cell.IsAlive.Should().BeTrue();
        }

        [TestMethod]
        public void LiveCell_WithTwoLive_Should_Go_To_NextGeneration()
        {
            Board board = new Board(2, 2)
                .GenerateDeadRows()
                .SetLiveCell(0, 0)
                .SetLiveCell(0, 1)
                .SetLiveCell(1, 0);

            var cell = board.TryGetCell(0, 0);
            cell.IsAlive.Should().BeTrue();

            bool isChanged = LiveRuleService.Instance.ApplyRules(board, cell);
            isChanged.Should().BeFalse();
            cell.IsAlive.Should().BeTrue();
        }

        [TestMethod]
        public void LiveCell_WithOverPopulation_Should_Die()
        {
            Board board = new Board(4, 4)
                .GenerateDeadRows()
                .SetLiveCell(1, 1);

            var cell = board.TryGetCell(1, 1);
            cell.IsAlive.Should().BeTrue();

            bool isChanged = LiveRuleService.Instance.ApplyRules(board, cell);
            isChanged.Should().BeTrue();
            cell.IsDead.Should().BeTrue();
            cell.IsAlive.Should().BeFalse();
        }
    }
}
