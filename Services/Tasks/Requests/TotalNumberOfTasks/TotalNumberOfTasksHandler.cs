using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Tasks;
using System;
using System.Collections.Generic;

namespace Services.Tasks.Requests.TotalNumberOfTasks
{
    public class TotalNumberOfTasksHandler : RequestSafeHandler<TotalNumberOfTasksRequest, TotalStatistics<DateTime>>
    {
        private readonly ITaskDataAccess _taskDataAccess = new TaskDataAccess();
        
        protected override TotalStatistics<DateTime> Execute(TotalNumberOfTasksRequest request)
        {
            //Validation
            if (request.TaskFilter == null)
            {
                throw new ArgumentNullException(nameof(request.TaskFilter));
            }

            //Do business logic
            //Get data from DataAccess
            List<StatisticsEntry<DateTime>> entries = _taskDataAccess.TotalNumberOfTasks(request.TaskFilter);

            //Do more business logic and validation?
            //Build and return result
            TotalStatistics<DateTime> statistics = new(request.TaskFilter, entries);
            return statistics;
        }
    }
}
