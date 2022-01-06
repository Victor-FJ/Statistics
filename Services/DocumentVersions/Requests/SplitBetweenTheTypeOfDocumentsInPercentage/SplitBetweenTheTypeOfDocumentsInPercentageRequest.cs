using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.DocumentVersions;
using DataAccess.Statistics;

namespace Services.DocumentVersions.Requests.SplitBetweenTheTypeOfDocumentsInPercentage
{
    public class SplitBetweenTheTypeOfDocumentsInPercentageRequest : Request<NumberStatistics<DocumentVersionTypePercentage>>
    {
        public DateFilter DateFilter { get; set; }
        
        public SplitBetweenTheTypeOfDocumentsInPercentageRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
