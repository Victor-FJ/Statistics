using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Users;

namespace Services.Users.Requests.TotalNumberOfUsers
{
    public class TotalNumberOfUsersHandler : RequestSafeHandler<TotalNumberOfUsersRequest, TotalStatistics<DateTime>>
    {
        public IUserDataAccess _dataAccess = new UserDataAccess();
        
        protected override TotalStatistics<DateTime> Execute(TotalNumberOfUsersRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<StatisticsEntry<DateTime>> entries = _dataAccess.TotalNumberOfUsers(request.DateFilter);
            //Do more business logic and validation?
            //Build and return result
            TotalStatistics<DateTime> statistics = new (request.DateFilter, entries);
            return statistics;
        }
    }
}
