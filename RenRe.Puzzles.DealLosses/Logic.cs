using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RenRe.Puzzles.DealLosses
{
    public static class Logic
    {
        /// <summary>
        /// Option is is [peril x location] unique combination. it binds two attributes of event into single one.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string GetOption(enPeril p, enLocation l)
        {
            return $"{(int)p}¤{(int)l}";
        }


        public static List<enPeril> GetPerilsfromIntArray(int[] perils)
        {
            var perilsIntList = perils.OfType<int>().ToList();
            return perilsIntList.Select(i => (enPeril)i).ToList();
        }

        public static List<enLocation> GetLocationsfromIntArray(int[] locations)
        {
            var locationsIntList = locations.OfType<int>().ToList();
            return locationsIntList.Select(i => (enLocation)i).ToList();
        }

        private static bool IsEventCovered(Event e, Deal d)
        {
            return d.CoveredOptions.Contains(e.Option);
        }

        private static int CalculateOurCosts(Event e, Deal d)
        {
            if (!IsEventCovered(e, d))
                return -1;

            if (e.TotalLoss <= d.Retention)
                return 0;

            return Math.Min(d.Limit, e.TotalLoss - d.Retention);

        }

        public static string CalculationAsText(Event e, Deal d)
        {
            int ourCost = CalculateOurCosts(e, d);
            if (ourCost == -1)
                return $"{d.ToString()} does not cover {e.ToString()}.";
            else
                return $"{e.ToString()} for {d.ToString()} costs our insurance: {ourCost}.";
        }

    }
}
