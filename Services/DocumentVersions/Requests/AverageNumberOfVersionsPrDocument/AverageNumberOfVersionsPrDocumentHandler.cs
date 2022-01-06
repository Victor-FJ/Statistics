using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.DocumentVersions;

namespace Services.DocumentVersions.Requests.AverageNumberOfVersionsPrDocument
{
    public class AverageNumberOfVersionsPrDocumentHandler : RequestSafeHandler<AverageNumberOfVersionsPrDocumentRequest, NumberStatistics<int>>
    {
        private readonly IDocumentVersionDataAccess _dataAccess = new DocumentVersionDataAccess();
        
        protected override NumberStatistics<int> Execute(AverageNumberOfVersionsPrDocumentRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            double average = _dataAccess.AverageNumberOfVersionsPrDocument(request.DateFilter);
            //Do more business logic and validation?
            //Build and return result
            NumberStatistics<int> statistics = new (request.DateFilter, (int)Math.Round(average));
            return statistics;
        }
    }
}
