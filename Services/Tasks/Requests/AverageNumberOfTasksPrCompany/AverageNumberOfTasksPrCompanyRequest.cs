using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tasks.Requests.AverageNumberOfTasksPrCompany
{
    public class AverageNumberOfTasksPrCompanyRequest : Request<NumberStatistics<int>>
    {
        public TaskFilter TaskFilter { get; set; }

        public AverageNumberOfTasksPrCompanyRequest(TaskFilter taskFilter)
        {
            TaskFilter = taskFilter;
        }
    }
}
