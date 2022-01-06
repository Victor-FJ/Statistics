using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Organizations;

namespace Services.Organizations.Requests.TotalNumberOfCompanies
{
    public class TotalNumberOfCompaniesHandler : RequestSafeHandler<TotalNumberOfCompaniesRequest, TotalStatistics<DateTime>>
    {
        public IOrganizationDataAccess _dataAccess = new OrganizationDataAccess();
        
        protected override TotalStatistics<DateTime> Execute(TotalNumberOfCompaniesRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<StatisticsEntry<DateTime>> entries = _dataAccess.TotalNumberOfCompanies(request.DateFilter);
            //Do more business logic and validation?
            //Build and return result
            TotalStatistics<DateTime> statistics = new (request.DateFilter, entries);
            return statistics;
        }
    }
}
