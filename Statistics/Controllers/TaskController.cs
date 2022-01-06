using Microsoft.AspNetCore.Mvc;
using System;
using DataAccess.Statistics;
using Services.Interfaces;
using DataAccess.Tasks;
using CC.Mediator;
using Services.Tasks.Requests.TotalNumberOfTasks;
using Services.Tasks.Requests.AverageNumberOfTasksPrCompany;
using Services.Tasks.Requests.NumberOfDedicatedTasks;
using System.Threading.Tasks;

namespace Statistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : NswagController
    {
        [HttpGet("TotalNumberOfTasks")]
        public async Task<ActionResult<TotalStatistics<DateTime>>> TotalNumberOfTasks([FromBody]TaskFilter filter)
        {
            TotalNumberOfTasksRequest request = new(filter);
            return await SendRequest(request);
        }

        [HttpGet("AverageNumberOfTasksPrCompany")]
        public async Task<ActionResult<NumberStatistics<int>>> AverageNumberOfTasksPrCompany([FromBody] TaskFilter filter)
        {
            var request = new AverageNumberOfTasksPrCompanyRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("NumberOfDedicatedTasks")]
        public async Task<ActionResult<NumberStatistics<int>>> NumberOfDedicatedTasks([FromBody] TaskFilter filter)
        {
            var request = new NumberOfDedicatedTasksRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("NumberOfCustomTasks")]
        public async Task<ActionResult<NumberStatistics<int>>> NumberOfCustomTasks([FromBody] TaskFilter filter)
        {
            var request = new NumberOfCustomTasksRequest(filter);
            return await SendRequest(request);
        }
    }
}
