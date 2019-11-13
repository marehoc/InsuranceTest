using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RenRe.Puzzles.DealLosses.Entities
{
    public class Event
    {
        public Event (int id, int p, int l, int tl)
        {
            Id = id;
            Peril = (enPeril)p;
            Location = (enLocation)l;
            TotalLoss = tl;
        }

        public Event(int[] data)
        {
            Id = data[0];
            Peril = (enPeril)data[1];
            Location = (enLocation)data[2];
            TotalLoss = data[3];
        }

        public int Id { get; private set; }
        public enPeril Peril { get; private set; }
        public enLocation Location { get; private set; }
        public int TotalLoss { get; private set; }

        public string Option
        {
            get { return Event.GetOption(Peril, Location); }
        }

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

        public override string ToString()
        {
            return $"Event {Id}";
        }

        public  string ToLongString()
        {
            return $"Event {Id}: {Peril.ToString()} in {Location.ToString()} with Total Loss={TotalLoss}.";
        }

    }

}
