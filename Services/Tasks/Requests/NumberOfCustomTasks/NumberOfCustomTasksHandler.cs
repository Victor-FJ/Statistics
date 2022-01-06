using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Tasks;
using System;
using System.Collections.Generic;

namespace Services.Tasks.Requests.TotalNumberOfTasks
{
    public class NumberOfCustomTasksHandler : RequestSafeHandler<NumberOfCustomTasksRequest, NumberStatistics<int>>
    {
        private readonly ITaskDataAccess _taskDataAccess = new TaskDataAccess();
        
        protected override NumberStatistics<int> Execute(NumberOfCustomTasksRequest request)
        {
            TaskFilter filter = request.TaskFilter;

            int count = _taskDataAccess.NumberOfCustomTasks(filter);

            NumberStatistics<int> statistics = new(filter, count);
            return statistics;
        }
    }
}
