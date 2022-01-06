using System;
using System.Linq.Expressions;

namespace DataAccess.Statistics
{
    public class DateFilter
    {
        public DateTime FromDate { get; set; } = DateTime.MinValue;
        public DateTime ToDate { get; set; } = DateTime.MaxValue;

        public virtual Expression<Func<T, bool>> GetFilter<T>() where T : BaseEntity => x => FromDate < x.CreatedDate && x.CreatedDate < ToDate;
    }
}
