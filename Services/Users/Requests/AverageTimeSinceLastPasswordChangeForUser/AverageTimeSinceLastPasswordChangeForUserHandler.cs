using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Extensions;
using DataAccess.Statistics;
using DataAccess.Users;

namespace Services.Users.Requests.AverageTimeSinceLastPasswordChangeForUser
{
    public class AverageTimeSinceLastPasswordChangeForUserHandler : RequestSafeHandler<AverageTimeSinceLastPasswordChangeForUserRequest, NumberStatistics<TimeSpan>>
    {
        private readonly IUserDataAccess _dataAccess = new UserDataAccess();
        
        protected override NumberStatistics<TimeSpan> Execute(AverageTimeSinceLastPasswordChangeForUserRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<DateTime> lastPasswordChangeDates = _dataAccess.AverageTimeSinceLastPasswordChangeForUser(request.DateFilter);
            //Do more business logic and validation?
            DateTime now = DateTime.Now;
            TimeSpan average = lastPasswordChangeDates.Select(x => now.Subtract(x)).AverageTimeSpan();
            //Build and return result
            NumberStatistics<TimeSpan> statistics = new(request.DateFilter, average);
            return statistics;
        }
    }
}
