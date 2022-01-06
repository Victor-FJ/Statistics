using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Organizations;
using DataAccess.Tasks.Models;

namespace Services.Organizations.Requests.AverageComplianceLevelForCompanies
{
    public class AverageComplianceLevelForCompaniesHandler : RequestSafeHandler<AverageComplianceLevelForCompaniesRequest, NumberStatistics<int>>
    {
        public IOrganizationDataAccess _dataAccess = new OrganizationDataAccess();
        
        protected override NumberStatistics<int> Execute(AverageComplianceLevelForCompaniesRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<TaskEntity> tasks = _dataAccess.AverageComplianceLevelForCompanies(request.DateFilter);
            //Do more business logic and validation?
            double average = tasks.GroupBy(x => x.CompanyId)
                                  .Average(ComplianceLevelHandler.ComplianceLevel);
            //Build and return result
            NumberStatistics<int> statistics = new (request.DateFilter, (int)Math.Round(average));
            return statistics;
        }
    }
}
