using System;
using System.Collections.Generic;
using DataAccess.Statistics;
using DataAccess.Tasks;
using DataAccess.Tasks.Models;
using MediatR;
using Services.Interfaces;

namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskDataAccess _taskDataAccess;

        public TaskService(ITaskDataAccess taskDataAccess)
        {
            _taskDataAccess = taskDataAccess;
        }

        public TotalStatistics<DateTime> TotalNumberOfTasks(TaskFilter filter)
        {
            List<StatisticsEntry<DateTime>> entries = _taskDataAccess.TotalNumberOfTasks(filter);

            TotalStatistics<DateTime> statistics = new(filter, entries);
            return statistics;
        }

        public NumberStatistics<int> AverageNumberOfTasksPrCompany(TaskFilter filter)
        {
            double average = _taskDataAccess.AverageNumberOfTasksPrCompany(filter);

            NumberStatistics<int> statistics = new(filter, (int)Math.Round(average));
            return statistics;
        }

        public NumberStatistics<int> NumberOfDedicatedTasks(TaskFilter filter)
        {
            int count = _taskDataAccess.NumberOfDedicatedTasks(filter);

            NumberStatistics<int> statistics = new(filter, count);
            return statistics;
        }

        public NumberStatistics<int> NumberOfCustomTasks(TaskFilter filter)
        {
            int count = _taskDataAccess.NumberOfCustomTasks(filter);

            NumberStatistics<int> statistics = new(filter, count);
            return statistics;
        }
    }
}
