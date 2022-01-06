using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tasks.Requests.NumberOfDedicatedTasks
{
    public class NumberOfDedicatedTasksHandler : RequestSafeHandler<NumberOfDedicatedTasksRequest, NumberStatistics<int>>
    {
        private readonly ITaskDataAccess _taskDataAccess = new TaskDataAccess();

        protected override NumberStatistics<int> Execute(NumberOfDedicatedTasksRequest request)
        {
            TaskFilter filter = request.TaskFilter;

            int count = _taskDataAccess.NumberOfDedicatedTasks(filter);

            NumberStatistics<int> statistics = new(filter, count);
            return statistics;
        }
    }
}
