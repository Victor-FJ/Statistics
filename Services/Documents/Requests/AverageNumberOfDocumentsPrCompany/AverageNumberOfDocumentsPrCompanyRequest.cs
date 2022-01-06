using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Documents.Requests.AverageNumberOfDocumentsPrCompany
{
    public class AverageNumberOfDocumentsPrCompanyRequest : Request<NumberStatistics<int>>
    {
        public DateFilter DateFilter { get; set; }
        
        public AverageNumberOfDocumentsPrCompanyRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
