using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Organizations;

namespace Services.Organizations.Requests.AverageNumberOfCompaniesInTheSameGroup
{
    public class AverageNumberOfCompaniesInTheSameGroupHandler : RequestSafeHandler<AverageNumberOfCompaniesInTheSameGroupRequest, NumberStatistics<int>>
    {
        public IOrganizationDataAccess _dataAccess = new OrganizationDataAccess();
        
        protected override NumberStatistics<int> Execute(AverageNumberOfCompaniesInTheSameGroupRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<OrganizationNode> organizationEntities = _dataAccess
                .AverageNumberOfCompaniesInTheSameGroup(request.DateFilter)
                .Select(x => x.ToNode()).ToList();
            //Do more business logic and validation?
            IEnumerable<IGrouping<bool, OrganizationNode>> organizationEntitiesGrouped = organizationEntities
                .GroupBy(node => node.ParentId != null && node.ParentId != Guid.Empty);

            List<OrganizationNode> topParentOrganizations = organizationEntitiesGrouped.Single(x => !x.Key).ToList();
            List<OrganizationNode> childOrganizations = organizationEntitiesGrouped.Single(x => x.Key).ToList();


            childOrganizations.ForEach(node => organizationEntities.Single(parent => parent.Id == node.ParentId).Nodes.Add(node));

            double average = topParentOrganizations.Select(topParent => topParent.CountAll()).Average();
            //Build and return result
            NumberStatistics<int> statistics = new(request.DateFilter, (int)Math.Round(average));
            return statistics;
        }
    }
}
