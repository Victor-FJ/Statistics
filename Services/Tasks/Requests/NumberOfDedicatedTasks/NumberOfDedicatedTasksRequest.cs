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
    public class NumberOfDedicatedTasksRequest : Request<NumberStatistics<int>>
    {
        public TaskFilter TaskFilter { get; set; }

        public NumberOfDedicatedTasksRequest(TaskFilter taskFilter)
        {
            TaskFilter = taskFilter;
        }
    }
}
