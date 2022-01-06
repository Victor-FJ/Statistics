
using DataAccess.Statistics;
using DataAccess.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Users
{
    public interface IUserDataAccess
    {
        List<StatisticsEntry<DateTime>> TotalNumberOfUsers(DateFilter dateFilter);

        List<List<UserRole>> AverageNumberOfUsersPrCompany(DateFilter dateFilter);

        List<DateTime> AverageTimeSinceLastPasswordChangeForUser(DateFilter dateFilter);

        List<DateTime> AverageTimeSinceLastLoginForUser(DateFilter dateFilter);
    }
}
