using DataAccess.Organizations.Models;
using DataAccess.Statistics;
using DataAccess.Tasks.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Organizations
{
    public interface IOrganizationDataAccess
    {
        public List<StatisticsEntry<DateTime>> TotalNumberOfOrganizations(DateFilter dateFilter);

        public List<StatisticsEntry<DateTime>> TotalNumberOfCompanies(DateFilter dateFilter);

        public List<StatisticsEntry<DateTime>> TotalNumberOfThirdParties(DateFilter dateFilter);

        public double AverageNumberOfRelatedThirdPartyOrganizationsForACompany(DateFilter dateFilter);

        public List<OrganizationNodeData> AverageNumberOfCompaniesInTheSameGroup(DateFilter dateFilter);

        public List<StatisticsEntry<DateTime>> TotalNumberOfThirdPartiesCreatedFromTheMetaLayer(DateFilter dateFilter);

        public List<TaskEntity> AverageComplianceLevelForCompanies(DateFilter dateFilter);
    }
}
