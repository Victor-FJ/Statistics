using DataAccess.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public interface IUserService
    {
        public TotalStatistics<DateTime> TotalNumberOfUsers(DateFilter dateFilter);

        public NumberStatistics<int> AverageNumberOfUsersPrCompany(DateFilter dateFilter);

        public NumberStatistics<TimeSpan> AverageTimeSinceLastPasswordChangeForUser(DateFilter dateFilter);

        public NumberStatistics<TimeSpan> AverageTimeSinceLastLoginForUser(DateFilter dateFilter);
    }
}
