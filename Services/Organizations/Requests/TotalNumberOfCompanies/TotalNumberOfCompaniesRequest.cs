using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Organizations.Requests.TotalNumberOfCompanies
{
    public class TotalNumberOfCompaniesRequest : Request<TotalStatistics<DateTime>>
    {
        public DateFilter DateFilter { get; set; }
        
        public TotalNumberOfCompaniesRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
