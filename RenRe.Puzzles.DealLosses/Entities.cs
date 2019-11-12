using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RenRe.Puzzles.DealLosses
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
            get { return Logic.GetOption(Peril, Location); }
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

    public class Deal
    {
        public Deal(int id, int r, int l, int[] perils, int[] locations)
        {
            Id = id;
            Retention = r;
            Limit = l;
            Perils = Logic.GetPerilsfromIntArray(perils);
            Locations = Logic.GetLocationsfromIntArray(locations);
        }

        public int Id { get; private set; }
        public int Retention { get; private set; }
        public int Limit { get; private set; }
        public List<enPeril> Perils { get; private set; }
        public List<enLocation> Locations { get; private set; }

        List<string> coveredOptions = null;
        public List<string> CoveredOptions
        {
            get
            {
                if (coveredOptions == null)
                    coveredOptions = GetMyOptions();

                return coveredOptions;
            }
        }

        private List<string> GetMyOptions()
        {
            List<string> r = new List<string>();
            foreach (enPeril p in Perils)
            {
                foreach (enLocation l in Locations)
                {
                    r.Add(Logic.GetOption(p, l));
                }
            }
            return r;
        }

        private string PerilsAsText()
        {
            return $"({string.Join(" and ", Perils.Select(p => p.ToString()).ToArray())})";
        }
        private string LocationsAsText()
        {
            return $"({string.Join(" and ", Locations.Select(l => l.ToString()).ToArray())})";
        }

        public override string ToString()
        {
            return $"Deal {Id}";
        }

        public string ToLongString()
        {
            return $"Deal {Id}: For {PerilsAsText()} in {LocationsAsText()} with R={Retention} and L={Limit}.";
        }

    }

}
