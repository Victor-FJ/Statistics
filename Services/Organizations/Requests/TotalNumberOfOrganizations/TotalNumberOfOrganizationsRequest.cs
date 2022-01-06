using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Organizations.Requests.TotalNumberOfOrganizations
{
    public class TotalNumberOfOrganizationsRequest : Request<TotalStatistics<DateTime>>
    {
        public DateFilter DateFilter { get; set; }
        
        public TotalNumberOfOrganizationsRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
