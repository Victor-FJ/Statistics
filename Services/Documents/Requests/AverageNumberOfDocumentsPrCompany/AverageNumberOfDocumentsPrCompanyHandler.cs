using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Documents;

namespace Services.Documents.Requests.AverageNumberOfDocumentsPrCompany
{
    public class AverageNumberOfDocumentsPrCompanyHandler : RequestSafeHandler<AverageNumberOfDocumentsPrCompanyRequest, NumberStatistics<int>>
    {
        private readonly IDocumentDataAccess _dataAccess = new DocumentDataAccess();
        
        protected override NumberStatistics<int> Execute(AverageNumberOfDocumentsPrCompanyRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            double average = _dataAccess.AverageNumberOfDocumentsPrCompany(request.DateFilter);
            //Do more business logic and validation?
            //Build and return result
            NumberStatistics<int> statistics = new (request.DateFilter, (int)Math.Round(average));
            return statistics;
        }
    }
}
