using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Users;
using DataAccess.Users.Models;

namespace Services.Users.Requests.AverageNumberOfUsersPrCompany
{
    public class AverageNumberOfUsersPrCompanyHandler : RequestSafeHandler<AverageNumberOfUsersPrCompanyRequest, NumberStatistics<int>>
    {
        public IUserDataAccess _dataAccess = new UserDataAccess();
        
        protected override NumberStatistics<int> Execute(AverageNumberOfUsersPrCompanyRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<List<UserRole>> usersUserRoles = _dataAccess.AverageNumberOfUsersPrCompany(request.DateFilter);
            //Do more business logic and validation?
            double average = usersUserRoles.SelectMany(userRoles => userRoles.GroupBy(role => role.CompanyId)
                                                                             .Where(roleGroup => roleGroup.Count() >= 2))
                                           .GroupBy(roleGroup => roleGroup.Key)
                                           .Average(companyIdGroup => companyIdGroup.Count());
            //Build and return result
            NumberStatistics<int> statistics = new(request.DateFilter, (int)Math.Round(average));
            return statistics;
        }
    }
}
