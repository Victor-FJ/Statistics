using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Mediator;
using DataAccess.Statistics;

namespace Services.Organizations.Requests.TotalNumberOfThirdPartiesCreatedFromTheMetaLayer
{
    public class TotalNumberOfThirdPartiesCreatedFromTheMetaLayerRequest : Request<TotalStatistics<DateTime>>
    {
        public DateFilter DateFilter { get; set; }

        public TotalNumberOfThirdPartiesCreatedFromTheMetaLayerRequest(DateFilter dateFilter)
        {
            DateFilter = dateFilter;
        }
    }
}
