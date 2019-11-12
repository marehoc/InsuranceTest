using System;
using System.Collections.Generic;

namespace RenRe.Puzzles.DealLosses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to insurance calculation!");
            Console.WriteLine("Press R to run calculation...");

            string input = Console.ReadLine();

            if (input.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                FinalOutput();

            Console.WriteLine("Press enter to terminate...");
            Console.ReadLine();
            Environment.Exit(0);
        }

        private static void FinalOutput()
        {
            
            List<Event> events = MidTier.EventList();
            List<Deal> deals = MidTier.DealList();

            Console.Write(MidTier.GetSummaryInput(events, deals));
            Console.Write(MidTier.GetSummaryResult(events, deals));

        }
    }
}
