using System;

namespace RenRe.Puzzles.DealLosses.Logic
{
    public static class Calculator
    {

        public static int CalculateOurCosts(bool eventCovered, int totalLoss, int retention, int limit)
        {
            if (totalLoss < 0 || retention < 0 || limit < 0)
                throw new ArgumentException("Negative inputs are not allowed.");

            if (retention >= limit)
                throw new ArgumentException("Retention must be lower than limit.");

            if (!eventCovered)
                return -1;

            return EventCoveredCalculation(totalLoss, retention, limit);

        }

        public static int EventCoveredCalculation(int totalLoss, int retention, int limit)
        {
            if (totalLoss <= retention)
                return 0;

            return Math.Min(limit, totalLoss - retention);
        }


    }
}
