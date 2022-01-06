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
    public class AverageNumberOfTasksPrCompanyHandler : RequestSafeHandler<AverageNumberOfTasksPrCompanyRequest, NumberStatistics<int>>
    {
        private readonly ITaskDataAccess _taskDataAccess = new TaskDataAccess();

        protected override NumberStatistics<int> Execute(AverageNumberOfTasksPrCompanyRequest request)
        {
            TaskFilter filter = request.TaskFilter;

            double average = _taskDataAccess.AverageNumberOfTasksPrCompany(filter);

            NumberStatistics<int> statistics = new(filter, (int)Math.Round(average));
            return statistics;
        }
    }
}
