using System;
using System.Collections.Generic;
using System.Text;
using RenRe.Puzzles.DealLosses.Entities;
using RenRe.Puzzles.DealLosses.Logic;
using RenRe.Puzzles.DealLosses.DbLayer;

namespace RenRe.Puzzles.DealLosses
{
    public class MidTier
    {

        public static List<Event> EventList()
        {
            int[][] Events = Data.Events;

            List<Event> r = new List<Event>();
            for (int i = 0; i < Events.Length; i++)
            {
                r.Add(new Event(Events[i][0], Events[i][1], Events[i][2], Events[i][3]));
            }
            return r;
        }

        public static List<Deal> DealList()
        {
            Deal[] Deals = Data.Deals;

            List<Deal> r = new List<Deal>();
            for (int i = 0; i < Deals.Length; i++)
            {
                r.Add(Deals[i]);
            }
            return r;
        }

        public static string GetSummaryResult(List<Event> events, List<Deal> deals)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("OUTPUT is:");
            foreach (Event e in events)
            {
                foreach (Deal d in deals)
                {
                    sb.AppendLine(CalculationAsText(e, d));
                }
            }
            sb.AppendLine();

            return sb.ToString();
        }

        public static string GetSummaryInput(List<Event> events, List<Deal> deals)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INPUT Events are:");
            foreach (Event e in events)
            {
                sb.AppendLine(e.ToLongString());
            }
            sb.AppendLine();

            sb.AppendLine("INPUT Deals are:");
            foreach (Deal d in deals)
            {
                sb.AppendLine(d.ToLongString());
            }
            sb.AppendLine();

            return sb.ToString();
        }

        private static string CalculationAsText(Event e, Deal d)
        {
            int ourCost = Calculator.CalculateOurCosts(d.IsEventCovered(e), e.TotalLoss, d.Retention, d.Limit);

            if (ourCost == -1)
                return $"{d.ToString()} does not cover {e.ToString()}.";
            else
                return $"{e.ToString()} for {d.ToString()} costs our insurance company: {ourCost}.";
        }


    }
}
