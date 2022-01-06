using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Organizations.Requests.AverageComplianceLevelForCompanies
{
    public class AverageComplianceLevelForCompaniesRequest : Request<NumberStatistics<int>>
    {
        public DateFilter DateFilter { get; set; }
        
        public AverageComplianceLevelForCompaniesRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
