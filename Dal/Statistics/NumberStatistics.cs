using System;

namespace DataAccess.Statistics
{
    public class NumberStatistics<T>
    {
        public DateFilter Filter { get; set; }
        public T Result { get; set; }


        public NumberStatistics()
        {
        }

        public NumberStatistics(DateFilter filter, T result)
        {
            Filter = filter;
            Result = result;
        }
    }
}
