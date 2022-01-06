using DataAccess.Extensions;
using DataAccess.Organizations.Enums;
using DataAccess.Organizations.Models;
using DataAccess.Statistics;
using DataAccess.Tasks.Enum;
using DataAccess.Tasks.Models;
using DataAccess.Tools;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Organizations
{
    public class OrganizationDataAccess : GeneralDataAccess<OrganizationEntity>, IOrganizationDataAccess
    {
        public List<StatisticsEntry<DateTime>> TotalNumberOfOrganizations(DateFilter dateFilter) 
            => TotalNumberOfEntity(dateFilter.GetFilter<OrganizationEntity>());

        public List<StatisticsEntry<DateTime>> TotalNumberOfCompanies(DateFilter dateFilter) 
            => TotalNumberOfEntity(dateFilter.GetFilter<OrganizationEntity>().CombineWithAnd(organization => organization.Type == OrganizationType.Company));

        public List<StatisticsEntry<DateTime>> TotalNumberOfThirdParties(DateFilter dateFilter) 
            => TotalNumberOfEntity(dateFilter.GetFilter<OrganizationEntity>().CombineWithAnd(organization => organization.Type == OrganizationType.ThirdParty));

        public double AverageNumberOfRelatedThirdPartyOrganizationsForACompany(DateFilter dateFilter) 
            => AverageNumberOfEntityPr(dateFilter.GetFilter<OrganizationEntity>().CombineWithAnd(organization => organization.Type == OrganizationType.ThirdParty), x => x.ParentId);

        public List<OrganizationNodeData> AverageNumberOfCompaniesInTheSameGroup(DateFilter dateFilter)
            => GetEntities(dateFilter.GetFilter<OrganizationEntity>().CombineWithAnd(organization => organization.Type == OrganizationType.Company), x => new OrganizationNodeData()
            {
                Id = x.Id,
                ParentId = x.ParentId
            });

        public List<StatisticsEntry<DateTime>> TotalNumberOfThirdPartiesCreatedFromTheMetaLayer(DateFilter dateFilter) 
            => TotalNumberOfEntity(dateFilter.GetFilter<OrganizationEntity>().CombineWithAnd(organization => organization.MetaId != null));

        public List<TaskEntity> AverageComplianceLevelForCompanies(DateFilter dateFilter)
        {
            using IDocumentSession session = Store.OpenSession();


            IRavenQueryable<TaskEntity> query = session.Query<TaskEntity>()
                .Where(dateFilter.GetFilter<TaskEntity>().CombineWithAnd(
                    task => task.Status == TaskStatus.Active));

            return query.ToList();
        }
    }
}
