using DataAccess.Statistics;
using DataAccess.Users;
using DataAccess.Users.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UserTest
    {
        private readonly Mock<IUserDataAccess> _userDataAccess = new Mock<IUserDataAccess>();

        [TestMethod]
        public void AverageTimeSinceLastPasswordChangeForUserTest()
        {
            //Arrange
            var filter = new DateFilter();
            var now = DateTime.Now;
            var data = new List<DateTime>()
            {
                now.AddDays(-1),
                now.AddDays(-5),
                now.AddDays(-10),
                now.AddDays(-2),
                now.AddDays(-20)
            };

            _userDataAccess.Setup(x => x.AverageTimeSinceLastPasswordChangeForUser(filter)).Returns(data);
            var userService = new UserService(_userDataAccess.Object);

            //Act
            NumberStatistics<TimeSpan> result = userService.AverageTimeSinceLastPasswordChangeForUser(filter);

            //Assert
            double expected = 7.6;
            double actual = Math.Round(result.Result.TotalDays, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AverageTimeSinceLastLoginForUserTest()
        {
            //Arrange
            var filter = new DateFilter();
            var now = DateTime.Now;
            var days = new List<int>()
            { 3, 2, 10, 14, 22 };
            var data = days.Select(x => now.AddDays(x * -1)).ToList();

            _userDataAccess.Setup(x => x.AverageTimeSinceLastLoginForUser(filter)).Returns(data);
            var userService = new UserService(_userDataAccess.Object);

            //Act
            NumberStatistics<TimeSpan> result = userService.AverageTimeSinceLastLoginForUser(filter);

            //Assert
            double expected = days.Average();
            double actual = Math.Round(result.Result.TotalDays, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AverageNumberOfUsersPrCompanyTest()
        {
            //Arrange
            var filter = new DateFilter();

            Guid company1 = Guid.NewGuid();
            Guid company2 = Guid.NewGuid();
            Guid company3 = Guid.NewGuid();
            Guid company4 = Guid.NewGuid();

            List<List<UserRole>> usersUserRoles = new List<List<UserRole>>
            {
                new List<UserRole>
                {
                    new UserRole(){ CompanyId = company1},
                    new UserRole(){ CompanyId = company1},
                    new UserRole(){ CompanyId = company1},
                    new UserRole(){ CompanyId = company2},
                    new UserRole(){ CompanyId = company2},
                    new UserRole(){ CompanyId = company3}
                },
                new List<UserRole>
                {
                    new UserRole(){ CompanyId = company4},
                    new UserRole(){ CompanyId = company4},
                    new UserRole(){ CompanyId = company3},
                    new UserRole(){ CompanyId = company3},
                    new UserRole(){ CompanyId = company2},
                    new UserRole(){ CompanyId = company2}
                },
                new List<UserRole>
                {
                    new UserRole(){ CompanyId = company2},
                }
                ,
                new List<UserRole>
                {
                    new UserRole(){ CompanyId = company1},
                    new UserRole(){ CompanyId = company1},
                }
            };

            _userDataAccess.Setup(x => x.AverageNumberOfUsersPrCompany(filter)).Returns(usersUserRoles);
            var userService = new UserService(_userDataAccess.Object);

            //Act
            NumberStatistics<int> result = userService.AverageNumberOfUsersPrCompany(filter);

            //Assert
            double expected = 2;
            Assert.AreEqual(expected, result.Result);
        }
    }
}
