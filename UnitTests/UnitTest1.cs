using DataAccess.Documents;
using DataAccess.Statistics;
using DataAccess.Tasks;
using DataAccess.Tasks.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Services;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Mock<ITaskDataAccess> _taskDataAccess = new Mock<ITaskDataAccess>();
        private TaskService taskService;

        [TestMethod]
        public void GIVEN_hmm_WHEN_øh_THEN_ehm()
        {
            //Arrange
            var filter = new TaskFilter();
            _taskDataAccess.Setup(x => x.TotalNumberOfTasks(filter)).Returns(new List<StatisticsEntry<DateTime>>() { new StatisticsEntry<DateTime>() { Key = DateTime.MinValue, Count = 10 } });
            
            taskService = new TaskService(_taskDataAccess.Object);

            //Act
            var result = taskService.TotalNumberOfTasks(filter);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TotalStatistics<DateTime>));
        }
    }
}
