using DataAccess.Statistics;
using DataAccess.Tasks.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Tasks
{
    public interface ITaskDataAccess
    {
        public List<StatisticsEntry<DateTime>> TotalNumberOfTasks(TaskFilter taskFilter);

        public double AverageNumberOfTasksPrCompany(TaskFilter taskFilter);

        public int NumberOfDedicatedTasks(TaskFilter taskFilter);

        public int NumberOfCustomTasks(TaskFilter taskFilter);
    }
}
