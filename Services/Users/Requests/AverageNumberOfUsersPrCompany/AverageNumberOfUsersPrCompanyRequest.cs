using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Users.Requests.AverageNumberOfUsersPrCompany
{
    public class AverageNumberOfUsersPrCompanyRequest : Request<NumberStatistics<int>>
    {
        public DateFilter DateFilter { get; set; }
        
        public AverageNumberOfUsersPrCompanyRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
