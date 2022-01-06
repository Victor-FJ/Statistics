using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Organizations;

namespace Services.Organizations.Requests.TotalNumberOfThirdParties
{
    public class TotalNumberOfThirdPartiesHandler : RequestSafeHandler<TotalNumberOfThirdPartiesRequest, TotalStatistics<DateTime>>
    {
        public IOrganizationDataAccess _dataAccess = new OrganizationDataAccess();
        
        protected override TotalStatistics<DateTime> Execute(TotalNumberOfThirdPartiesRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<StatisticsEntry<DateTime>> entries = _dataAccess.TotalNumberOfThirdParties(request.DateFilter);
            //Do more business logic and validation?
            //Build and return result
            TotalStatistics<DateTime> statistics = new (request.DateFilter, entries);
            return statistics;
        }
    }
}
