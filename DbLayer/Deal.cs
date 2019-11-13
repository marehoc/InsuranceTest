using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RenRe.Puzzles.DealLosses.DbLayer
{
    public class Deal
    {
        public Deal(int id, int r, int l, List<enPeril> perils, List<enLocation> locations)
        {
            Id = id;
            Retention = r;
            Limit = l;
            Perils = perils;
            Locations = locations;
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
                    r.Add(Event.GetOption(p, l));
                }
            }
            return r;
        }

        public bool IsEventCovered(Event e)
        {
            return CoveredOptions.Contains(e.Option);
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
