using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Organizations;

namespace Services.Organizations.Requests.AverageNumberOfRelatedThirdPartyOrganizationsForACompany
{
    public class AverageNumberOfRelatedThirdPartyOrganizationsForACompanyHandler : RequestSafeHandler<AverageNumberOfRelatedThirdPartyOrganizationsForACompanyRequest, NumberStatistics<int>>
    {
        public IOrganizationDataAccess _dataAccess = new OrganizationDataAccess();
        
        protected override NumberStatistics<int> Execute(AverageNumberOfRelatedThirdPartyOrganizationsForACompanyRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            double average = _dataAccess.AverageNumberOfRelatedThirdPartyOrganizationsForACompany(request.DateFilter);
            //Do more business logic and validation?
            //Build and return result
            NumberStatistics<int> statistics = new (request.DateFilter, (int)Math.Round(average));
            return statistics;
        }
    }
}
