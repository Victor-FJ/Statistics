using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Users.Requests.TotalNumberOfUsers
{
    public class TotalNumberOfUsersRequest : Request<TotalStatistics<DateTime>>
    {
        public DateFilter DateFilter { get; set; }
        
        public TotalNumberOfUsersRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
