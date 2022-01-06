using DataAccess.Organizations;
using DataAccess.Organizations.Models;
using DataAccess.Statistics;
using DataAccess.Tasks.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationDataAccess _organizationDataAccess;

        public OrganizationService(IOrganizationDataAccess organizationDataAccess)
        {
            _organizationDataAccess = organizationDataAccess;
        }

        public TotalStatistics<DateTime> TotalNumberOfOrganizations(DateFilter dateFilter)
        {
            List<StatisticsEntry<DateTime>> entries = _organizationDataAccess.TotalNumberOfOrganizations(dateFilter);
            
            TotalStatistics<DateTime> statistics = new (dateFilter, entries);
            return statistics;
        }

        public TotalStatistics<DateTime> TotalNumberOfCompanies(DateFilter dateFilter)
        {
            List<StatisticsEntry<DateTime>> entries = _organizationDataAccess.TotalNumberOfCompanies(dateFilter);
            
            TotalStatistics<DateTime> statistics = new (dateFilter, entries);
            return statistics;
        }

        public TotalStatistics<DateTime> TotalNumberOfThirdParties(DateFilter dateFilter)
        {
            List<StatisticsEntry<DateTime>> entries = _organizationDataAccess.TotalNumberOfThirdParties(dateFilter);
            
            TotalStatistics<DateTime> statistics = new (dateFilter, entries);
            return statistics;
        }

        public NumberStatistics<int> AverageNumberOfRelatedThirdPartyOrganizationsForACompany(DateFilter dateFilter)
        {
            double average = _organizationDataAccess.AverageNumberOfRelatedThirdPartyOrganizationsForACompany(dateFilter);

            NumberStatistics<int> statistics = new(dateFilter, (int)Math.Round(average));
            return statistics;
        }

        public NumberStatistics<int> AverageNumberOfCompaniesInTheSameGroup(DateFilter dateFilter)
        {
            List<OrganizationNode> organizationEntities = _organizationDataAccess
                .AverageNumberOfCompaniesInTheSameGroup(dateFilter)
                .Select(x => x.ToNode()).ToList();

            IEnumerable<IGrouping<bool, OrganizationNode>> organizationEntitiesGrouped = organizationEntities
                .GroupBy(node => node.ParentId != null && node.ParentId != Guid.Empty);

            List<OrganizationNode> topParentOrganizations = organizationEntitiesGrouped.Single(x => !x.Key).ToList();
            List<OrganizationNode> childOrganizations = organizationEntitiesGrouped.Single(x => x.Key).ToList();


            childOrganizations.ForEach(node => organizationEntities.Single(parent => parent.Id == node.ParentId).Nodes.Add(node));
            
            double average = topParentOrganizations.Select(topParent => topParent.CountAll()).Average();

            NumberStatistics<int> statistics = new(dateFilter, (int)Math.Round(average));
            return statistics;
        }

        public TotalStatistics<DateTime> TotalNumberOfThirdPartiesCreatedFromTheMetaLayer(DateFilter dateFilter)
        {
            List<StatisticsEntry<DateTime>> entries = _organizationDataAccess.TotalNumberOfThirdPartiesCreatedFromTheMetaLayer(dateFilter);
            
            TotalStatistics<DateTime> statistics = new (dateFilter, entries);
            return statistics;
        }

        public NumberStatistics<int> AverageComplianceLevelForCompanies(DateFilter dateFilter)
        {
            List<TaskEntity> tasks = _organizationDataAccess.AverageComplianceLevelForCompanies(dateFilter);

            double average = tasks.GroupBy(x => x.CompanyId)
                                  .Average(ComplianceLevelHandler.ComplianceLevel);

            NumberStatistics<int> statistics = new(dateFilter, (int)Math.Round(average));
            return statistics;
        }
    }
}
