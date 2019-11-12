using System.Collections.Generic;

namespace RenRe.Puzzles.DealLosses
{
    /// <summary>
    /// Conceptually this can be considered as data retrieved from an a database, filesystem or API
    /// </summary>
    public class Data
    {
        public static int[][] Events => new[]
        {
            new []{1, 2, 1, 1000},
            new []{2, 3, 2, 500},
            new []{3, 3, 3, 750},
            new []{4, 1, 3, 2000}
        };

        public static Deal[] Deals => new[]
        {
            new Deal(1, 100, 500, new[] { 2 }, new[] { 1 }),        //Deal 1 covers California earthquake, and is 500x100
            new Deal(2, 1000, 3000, new[] { 1 }, new[] { 3 }),      //Deal 2 covers Florida hurricane, and is 3000x1000
            new Deal(3, 250, 250, new[] { 1, 3 }, new[] { 2, 3 })   //Deal 3 covers Florida and Louisiana for both hurricane and flood and is 250x250
        };



    }
}