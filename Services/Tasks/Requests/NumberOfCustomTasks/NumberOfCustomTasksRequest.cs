using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Tasks;
using System;


namespace Services.Tasks.Requests.TotalNumberOfTasks
{
    public class NumberOfCustomTasksRequest : Request<NumberStatistics<int>>
    {
        public TaskFilter TaskFilter { get; set; }

        public NumberOfCustomTasksRequest(TaskFilter taskFilter)
        {
            TaskFilter = taskFilter;
        }
    }
}
