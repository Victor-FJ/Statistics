using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Documents.Requests.TotalNumberOfSharedocDocuments
{
    public class TotalNumberOfSharedocDocumentsRequest : Request<TotalStatistics<DateTime>>
    {
        public DateFilter DateFilter { get; set; }
        
        public TotalNumberOfSharedocDocumentsRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
