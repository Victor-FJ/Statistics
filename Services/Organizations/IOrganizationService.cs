using DataAccess.Statistics;
using System;

namespace Services.Interfaces
{
    public interface IOrganizationService
    {
        public TotalStatistics<DateTime> TotalNumberOfOrganizations(DateFilter dateFilter);

        public TotalStatistics<DateTime> TotalNumberOfCompanies(DateFilter dateFilter);

        public TotalStatistics<DateTime> TotalNumberOfThirdParties(DateFilter dateFilter);

        public NumberStatistics<int> AverageNumberOfRelatedThirdPartyOrganizationsForACompany(DateFilter dateFilter);

        public NumberStatistics<int> AverageNumberOfCompaniesInTheSameGroup(DateFilter dateFilter);

        public TotalStatistics<DateTime> TotalNumberOfThirdPartiesCreatedFromTheMetaLayer(DateFilter dateFilter);

        public NumberStatistics<int> AverageComplianceLevelForCompanies(DateFilter dateFilter);
    }
}
