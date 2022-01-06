using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Documents.Requests.MostUsedDocumentTypes
{
    public class MostUsedDocumentTypesRequest : Request<TotalStatistics<int>>
    {
        public DateFilter DateFilter { get; set; }
        
        public MostUsedDocumentTypesRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
