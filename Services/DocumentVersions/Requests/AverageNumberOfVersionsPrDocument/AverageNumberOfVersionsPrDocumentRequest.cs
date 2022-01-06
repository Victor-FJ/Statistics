using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.DocumentVersions.Requests.AverageNumberOfVersionsPrDocument
{
    public class AverageNumberOfVersionsPrDocumentRequest : Request<NumberStatistics<int>>
    {
        public DateFilter DateFilter { get; set; }
        
        public AverageNumberOfVersionsPrDocumentRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
