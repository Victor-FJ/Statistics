using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Organizations.Requests.TotalNumberOfThirdParties
{
    public class TotalNumberOfThirdPartiesRequest : Request<TotalStatistics<DateTime>>
    {
        public DateFilter DateFilter { get; set; }
        
        public TotalNumberOfThirdPartiesRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
