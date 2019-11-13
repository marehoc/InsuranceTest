using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RenRe.Puzzles.DealLosses.Logic;

namespace Testing
{
    public class CalculatorTest
    {

        [Fact]
        public void PassingTestUncoveredEvent()
        {
            Assert.Equal(-1, Calculator.CalculateOurCosts(false, 1, 1, 1));
        }

        [Fact]
        public void FailingTestUncoveredEvent()
        {
            Assert.Equal(0, Calculator.CalculateOurCosts(false, 1, 1, 1));
        }

        [Fact]
        public void PassingTestCoveredEvent1()
        {
            Assert.Equal(50, Calculator.EventCoveredCalculation(100, 20, 50));
        }

        [Fact]
        public void PassingTestCoveredEvent2()
        {
            Assert.Equal(100, Calculator.EventCoveredCalculation(100, 20, 500));
        }

        [Fact]
        public void PassingTestCoveredEvent3()
        {
            Assert.Equal(0, Calculator.EventCoveredCalculation(10, 20, 500));
        }

        [Theory]
        [InlineData(50, 100, 20, 50)]
        [InlineData(50, 50, 20, 50)]
        [InlineData(40, 40, 20, 50)]
        [InlineData(20, 20, 20, 50)]
        [InlineData(0, 10, 20, 50)]
        public void TextCoreCalculation(int expectedResult, int totalLoss, int retention, int limit)
        {
            Assert.True(expectedResult == Calculator.EventCoveredCalculation(totalLoss, retention, limit));
        }

        //TODO: TEST FOR ARGUMENT EXCEPTIONS

    }
}
