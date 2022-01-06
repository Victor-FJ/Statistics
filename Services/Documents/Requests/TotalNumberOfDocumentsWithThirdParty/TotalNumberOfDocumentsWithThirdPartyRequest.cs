using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Documents.Requests.TotalNumberOfDocumentsWithThirdParty
{
    public class TotalNumberOfDocumentsWithThirdPartyRequest : Request<TotalStatistics<DateTime>>
    {
        public DateFilter DateFilter { get; set; }
        
        public TotalNumberOfDocumentsWithThirdPartyRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
