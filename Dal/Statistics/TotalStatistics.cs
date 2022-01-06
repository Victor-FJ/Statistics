using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Statistics
{
    public class TotalStatistics<T>
    {
        public DateFilter Filter { get; set; }

        public int TotalNumberOfEntries => Entries.Sum(x => x.Count);
        public List<StatisticsEntry<T>> Entries { get; set; }


        public TotalStatistics()
        {
        }

        public TotalStatistics(DateFilter filter, List<StatisticsEntry<T>> entries)
        {
            Filter = filter;
            Entries = entries;
        }
    }
}
