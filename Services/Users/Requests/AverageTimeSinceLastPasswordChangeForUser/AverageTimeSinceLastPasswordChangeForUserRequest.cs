using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Users.Requests.AverageTimeSinceLastPasswordChangeForUser
{
    public class AverageTimeSinceLastPasswordChangeForUserRequest : Request<NumberStatistics<TimeSpan>>
    {
        public DateFilter DateFilter { get; set; }
        
        public AverageTimeSinceLastPasswordChangeForUserRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
