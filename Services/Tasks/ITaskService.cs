using DataAccess.Statistics;
using DataAccess.Tasks;
using System;

namespace Services.Interfaces
{
    public interface ITaskService
    {
        public TotalStatistics<DateTime> TotalNumberOfTasks(TaskFilter filter);

        public NumberStatistics<int> AverageNumberOfTasksPrCompany(TaskFilter filter);

        public NumberStatistics<int> NumberOfDedicatedTasks(TaskFilter filter);

        public NumberStatistics<int> NumberOfCustomTasks(TaskFilter filter);
    }
}
