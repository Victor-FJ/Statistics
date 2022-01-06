using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Documents;

namespace Services.Documents.Requests.MostUsedDocumentTypes
{
    public class MostUsedDocumentTypesHandler : RequestSafeHandler<MostUsedDocumentTypesRequest, TotalStatistics<int>>
    {
        private readonly IDocumentDataAccess _dataAccess = new DocumentDataAccess();
        
        protected override TotalStatistics<int> Execute(MostUsedDocumentTypesRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<StatisticsEntry<int>> entries = _dataAccess.MostUsedDocumentTypes(request.DateFilter);
            //Do more business logic and validation?
            //Build and return result
            TotalStatistics<int> statistics = new(request.DateFilter, entries);
            return statistics;
        }
    }
}
