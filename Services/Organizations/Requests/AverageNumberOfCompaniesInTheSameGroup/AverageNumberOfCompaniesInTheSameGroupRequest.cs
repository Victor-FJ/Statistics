using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Organizations.Requests.AverageNumberOfCompaniesInTheSameGroup
{
    public class AverageNumberOfCompaniesInTheSameGroupRequest : Request<NumberStatistics<int>>
    {
        public DateFilter DateFilter { get; set; }
        
        public AverageNumberOfCompaniesInTheSameGroupRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
