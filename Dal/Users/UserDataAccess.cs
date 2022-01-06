using DataAccess.Statistics;
using DataAccess.Tools;
using DataAccess.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Users
{
    public class UserDataAccess : GeneralDataAccess<UserEntity>, IUserDataAccess
    {
        public List<StatisticsEntry<DateTime>> TotalNumberOfUsers(DateFilter dateFilter)
            => TotalNumberOfEntity(dateFilter.GetFilter<UserEntity>());

        public List<List<UserRole>> AverageNumberOfUsersPrCompany(DateFilter dateFilter)
            => GetEntities(dateFilter.GetFilter<UserEntity>(), x => x.Roles);

        public List<DateTime> AverageTimeSinceLastPasswordChangeForUser(DateFilter dateFilter)
            => GetEntities(dateFilter.GetFilter<UserEntity>(), x => x.LastPasswordChangeDate);
            
        public List<DateTime> AverageTimeSinceLastLoginForUser(DateFilter dateFilter)
            => GetEntities(dateFilter.GetFilter<UserEntity>(), x => x.LastLoginDate);
    }
}
