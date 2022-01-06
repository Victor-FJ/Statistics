using DataAccess.Organizations;
using DataAccess.Statistics;
using DataAccess.Tasks.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class OrganizationTest
    {
        private readonly Mock<IOrganizationDataAccess> _organizationDataAccess = new Mock<IOrganizationDataAccess>();

        [TestMethod]
        public void AverageNumberOfCompaniesInTheSameGroupTest()
        {
            //Arrange
            var filter = new DateFilter();
            Guid parent1 = Guid.NewGuid();
            Guid parent2 = Guid.NewGuid();
            Guid parent3 = Guid.NewGuid();
            Guid parent4 = Guid.NewGuid();

            List<OrganizationNodeData> nodes = new List<OrganizationNodeData>
            {
                new OrganizationNodeData(parent1.ToString(), null),
                new OrganizationNodeData(parent2.ToString(), null),
                new OrganizationNodeData(parent3.ToString(), null),
                new OrganizationNodeData(parent4.ToString(), parent1),
                new OrganizationNodeData(Guid.NewGuid().ToString(), parent1),
                new OrganizationNodeData(Guid.NewGuid().ToString(), parent2),
                new OrganizationNodeData(Guid.NewGuid().ToString(), parent3),
                new OrganizationNodeData(Guid.NewGuid().ToString(), parent3),
                new OrganizationNodeData(Guid.NewGuid().ToString(), parent3),
                new OrganizationNodeData(Guid.NewGuid().ToString(), parent4),
            };

            _organizationDataAccess.Setup(x => x.AverageNumberOfCompaniesInTheSameGroup(filter)).Returns(nodes);
            var userService = new OrganizationService(_organizationDataAccess.Object);

            //Act
            NumberStatistics<int> result = userService.AverageNumberOfCompaniesInTheSameGroup(filter);

            //Assert
            int expected = 3;
            Assert.AreEqual(expected, result.Result);
        }


        [TestMethod]
        public void AverageComplianceLevelForCompaniesTest()
        {
            //Arrange
            var filter = new DateFilter();

            Guid company1 = Guid.NewGuid();
            Guid company2 = Guid.NewGuid();
            Guid company3 = Guid.NewGuid();

            List<TaskEntity> tasks = new List<TaskEntity>
            {
                new TaskEntity() { ActivationDate = DateTime.Now.AddDays(-5), CompanyId = company1},
                new TaskEntity() { ActivationDate = DateTime.Now.AddDays(-5), CompanyId = company1},
                new TaskEntity() { ActivationDate = DateTime.Now.AddDays(-5), CompanyId = company2},
                new TaskEntity() { ActivationDate = DateTime.Now.AddDays(-20), CompanyId = company2},
                new TaskEntity() { ActivationDate = DateTime.Now.AddDays(-40), CompanyId = company2},
                new TaskEntity() { ActivationDate = DateTime.Now.AddDays(-40), CompanyId = company3},
                new TaskEntity() { ActivationDate = DateTime.Now.AddDays(-40), CompanyId = company3},
                new TaskEntity() { ActivationDate = DateTime.Now.AddDays(-40), CompanyId = company3}
            };

            _organizationDataAccess.Setup(x => x.AverageComplianceLevelForCompanies(filter)).Returns(tasks);
            var userService = new OrganizationService(_organizationDataAccess.Object);

            //Act
            NumberStatistics<int> result = userService.AverageComplianceLevelForCompanies(filter);

            //Assert
            int expected = 82;
            Assert.AreEqual(expected, result.Result);
        }
    }
}
