using DataAccess.Statistics;
using DataAccess.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Extensions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Users.Models;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserDataAccess _userDataAccess;

        public UserService(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }
        public TotalStatistics<DateTime> TotalNumberOfUsers(DateFilter dateFilter)
        {
            List<StatisticsEntry<DateTime>> entries = _userDataAccess.TotalNumberOfUsers(dateFilter);

            TotalStatistics<DateTime> statistics = new(dateFilter, entries);
            return statistics;
        }

        public NumberStatistics<int> AverageNumberOfUsersPrCompany(DateFilter dateFilter)
        {
            List<List<UserRole>> usersUserRoles = _userDataAccess.AverageNumberOfUsersPrCompany(dateFilter);

            double average = usersUserRoles.SelectMany(userRoles => userRoles.GroupBy(role => role.CompanyId)
                                                                             .Where(roleGroup => roleGroup.Count() >= 2))
                                           .GroupBy(roleGroup => roleGroup.Key)
                                           .Average(companyIdGroup => companyIdGroup.Count());

            NumberStatistics<int> statistics = new(dateFilter, (int)Math.Round(average));
            return statistics;
        }

        public NumberStatistics<TimeSpan> AverageTimeSinceLastPasswordChangeForUser(DateFilter dateFilter)
        {
            List<DateTime> lastPasswordChangeDates = _userDataAccess.AverageTimeSinceLastPasswordChangeForUser(dateFilter);

            DateTime now = DateTime.Now;
            TimeSpan average = lastPasswordChangeDates.Select(x => now.Subtract(x)).AverageTimeSpan();

            NumberStatistics<TimeSpan> statistics = new(dateFilter, average);
            return statistics;
        }

        public NumberStatistics<TimeSpan> AverageTimeSinceLastLoginForUser(DateFilter dateFilter)
        {
            List<DateTime> lastPasswordChangeDates = _userDataAccess.AverageTimeSinceLastLoginForUser(dateFilter);

            DateTime now = DateTime.Now;
            TimeSpan average = lastPasswordChangeDates.Select(x => now.Subtract(x)).AverageTimeSpan();

            NumberStatistics<TimeSpan> statistics = new(dateFilter, average);
            return statistics;
        }
    }
}
