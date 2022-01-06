using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.DocumentVersions.Requests.TotalNumberOfDocumentVersions
{
    public class TotalNumberOfDocumentVersionsRequest : Request<TotalStatistics<DateTime>>
    {
        public DateFilter DateFilter { get; set; }
        
        public TotalNumberOfDocumentVersionsRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
