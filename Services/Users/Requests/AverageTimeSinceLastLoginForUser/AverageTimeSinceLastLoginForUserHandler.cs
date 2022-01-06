using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Extensions;
using DataAccess.Statistics;
using DataAccess.Users;

namespace Services.Users.Requests.AverageTimeSinceLastLoginForUser
{
    public class AverageTimeSinceLastLoginForUserHandler : RequestSafeHandler<AverageTimeSinceLastLoginForUserRequest, NumberStatistics<TimeSpan>>
    {
        public IUserDataAccess _dataAccess = new UserDataAccess();
        
        protected override NumberStatistics<TimeSpan> Execute(AverageTimeSinceLastLoginForUserRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<DateTime> lastLoginDates = _dataAccess.AverageTimeSinceLastLoginForUser(request.DateFilter);
            //Do more business logic and validation?
            DateTime now = DateTime.Now;
            TimeSpan average = lastLoginDates.Select(x => now.Subtract(x)).AverageTimeSpan();
            //Build and return result
            NumberStatistics<TimeSpan> statistics = new(request.DateFilter, average);
            return statistics;
        }
    }
}
