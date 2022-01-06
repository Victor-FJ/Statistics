using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extensions
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan AverageTimeSpan(this IEnumerable<TimeSpan> timeSpans)
            => TimeSpan.FromSeconds(timeSpans.Average(timeSpan => timeSpan.TotalSeconds));
    }
}
