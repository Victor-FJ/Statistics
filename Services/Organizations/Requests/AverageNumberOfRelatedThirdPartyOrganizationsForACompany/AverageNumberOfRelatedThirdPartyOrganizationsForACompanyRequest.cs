using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Organizations.Requests.AverageNumberOfRelatedThirdPartyOrganizationsForACompany
{
    public class AverageNumberOfRelatedThirdPartyOrganizationsForACompanyRequest : Request<NumberStatistics<int>>
    {
        public DateFilter DateFilter { get; set; }
        
        public AverageNumberOfRelatedThirdPartyOrganizationsForACompanyRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
