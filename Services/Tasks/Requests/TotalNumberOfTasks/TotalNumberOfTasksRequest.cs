using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Tasks;
using System;


namespace Services.Tasks.Requests.TotalNumberOfTasks
{
    public class TotalNumberOfTasksRequest : Request<TotalStatistics<DateTime>>
    {
        public TaskFilter TaskFilter { get; set; }

        public TotalNumberOfTasksRequest(TaskFilter taskFilter)
        {
            TaskFilter = taskFilter;
        }
    }
}
