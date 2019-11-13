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
        public void TestUncoveredEvent()
        {
            Assert.Equal(-1, Calculator.CalculateOurCosts(false, 1, 1, 1));
        }

        [Theory]
        [InlineData(50, 100, 20, 50)]
        [InlineData(50, 50, 20, 50)]
        [InlineData(40, 40, 20, 50)]
        [InlineData(20, 20, 20, 50)]
        [InlineData(0, 10, 20, 50)]
        [InlineData(0, 10, 10, 10)] 
        public void TextCoreCalculation(int expectedResult, int totalLoss, int retention, int limit)
        {
            Assert.True(expectedResult == Calculator.EventCoveredCalculation(totalLoss, retention, limit));
        }

        //TODO: TEST FOR ARGUMENT EXCEPTIONS

    }
}
