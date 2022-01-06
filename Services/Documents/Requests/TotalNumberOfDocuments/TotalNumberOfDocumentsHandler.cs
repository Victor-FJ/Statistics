using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Documents;

namespace Services.Documents.Requests.TotalNumberOfDocuments
{
    public class TotalNumberOfDocumentsHandler : RequestSafeHandler<TotalNumberOfDocumentsRequest, TotalStatistics<DateTime>>
    {
        private readonly IDocumentDataAccess _dataAccess = new DocumentDataAccess();
        
        protected override TotalStatistics<DateTime> Execute(TotalNumberOfDocumentsRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<StatisticsEntry<DateTime>> entries = _dataAccess.TotalNumberOfDocuments(request.DateFilter);
            //Do more business logic and validation?
            //Build and return result
            TotalStatistics<DateTime> statistics = new (request.DateFilter, entries);
            return statistics;
        }
    }
}
