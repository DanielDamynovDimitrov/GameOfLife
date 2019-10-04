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
        public void DiedCell_WithThreeLive_Should_Become_Live()
        {
            Board board = new Board(2, 2)
                .GenerateLiveCells()
                .SetDieCell(0, 0);
            var cell = board.TryGetCell(0, 0);
            cell.IsAlive.Should().BeFalse();
            cell.IsDead.Should().BeTrue();

            bool isChanged = LiveRuleService.Instance.ApplyRules(board, cell);
            isChanged.Should().BeTrue();

            board.RefreshState();
            cell.IsDead.Should().BeFalse();
        }

        [TestMethod]
        public void LiveCell_WithThreeLiveNeighbours_Should_Go_To_NextGeneration()
        {
            Board board = new Board(2, 2)
                .GenerateLiveCells();

            var cell = board.TryGetCell(0, 0);
            cell.IsAlive.Should().BeTrue();

            bool isChanged = LiveRuleService.Instance.ApplyRules(board, cell);
            isChanged.Should().BeFalse();

            board.RefreshState();
            cell.IsAlive.Should().BeTrue();
        }

        [TestMethod]
        public void LiveCell_WithTwoLiveNeighbours_Should_Go_To_NextGeneration()
        {
            Board board = new Board(2, 2)
                .GenerateLiveCells()
                .SetDieCell(0, 1);

            var cell = board.TryGetCell(0, 0);
            cell.IsAlive.Should().BeTrue();

            bool isChanged = LiveRuleService.Instance.ApplyRules(board, cell);
            isChanged.Should().BeFalse();

            board.RefreshState();
            cell.IsAlive.Should().BeTrue();
        }

        [TestMethod]
        public void LiveCell_WithUnderPopulation_Should_Die()
        {
            Board board = new Board(2, 2)
                .GenerateLiveCells()
                .SetDieCell(0, 1)
                .SetDieCell(1, 1);

            var cell = board.TryGetCell(0, 0);
            cell.IsAlive.Should().BeTrue();

            bool isChanged = LiveRuleService.Instance.ApplyRules(board, cell);
            isChanged.Should().BeTrue();

            board.RefreshState();
            cell.IsAlive.Should().BeFalse();
            cell.IsDead.Should().BeTrue();
        }

        [TestMethod]
        public void LiveCell_WithOverPopulation_Should_Die()
        {
            Board board = new Board(3, 3)
                .GenerateLiveCells();

            var cell = board.TryGetCell(1, 1);
            cell.IsAlive.Should().BeTrue();

            bool isChanged = LiveRuleService.Instance.ApplyRules(board, cell);
            isChanged.Should().BeTrue();

            board.RefreshState();
            cell.IsDead.Should().BeTrue();
        }
    }
}
