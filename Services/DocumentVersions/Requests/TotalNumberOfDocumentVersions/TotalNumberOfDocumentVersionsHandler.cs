using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.DocumentVersions;

namespace Services.DocumentVersions.Requests.TotalNumberOfDocumentVersions
{
    public class TotalNumberOfDocumentVersionsHandler : RequestSafeHandler<TotalNumberOfDocumentVersionsRequest, TotalStatistics<DateTime>>
    {
        public IDocumentVersionDataAccess _dataAccess = new DocumentVersionDataAccess();
        
        protected override TotalStatistics<DateTime> Execute(TotalNumberOfDocumentVersionsRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<StatisticsEntry<DateTime>> entries = _dataAccess.TotalNumberOfDocumentVersions(request.DateFilter);
            //Do more business logic and validation?
            //Build and return result
            TotalStatistics<DateTime> statistics = new (request.DateFilter, entries);
            return statistics;
        }
    }
}
