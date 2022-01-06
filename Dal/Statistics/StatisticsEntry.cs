using System;

namespace DataAccess.Statistics
{
    public class StatisticsEntry<T>
    {
        public T Key { get; set; }
        public int Count { get; set; }


        public override string ToString()
        {
            return $"{Key}, Count: {Count}";
        }
    }
}
