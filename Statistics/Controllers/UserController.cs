using CC.Mediator;
using DataAccess.Statistics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Users;
using Services.Users.Requests.AverageNumberOfUsersPrCompany;
using Services.Users.Requests.AverageTimeSinceLastLoginForUser;
using Services.Users.Requests.AverageTimeSinceLastPasswordChangeForUser;
using Services.Users.Requests.TotalNumberOfUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : NswagController
    {
        [HttpGet("TotalNumberOfUsers")]
        public async Task<ActionResult<TotalStatistics<DateTime>>> TotalNumberOfUsers([FromBody] DateFilter filter)
        {
            var request = new TotalNumberOfUsersRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("AverageNumberOfUsersPrCompany")]
        public async Task<ActionResult<NumberStatistics<int>>> AverageNumberOfUsersPrCompany([FromBody] DateFilter filter)
        {
            var request = new AverageNumberOfUsersPrCompanyRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("AverageTimeSinceLastPasswordChangeForUser")]
        public async Task<ActionResult<NumberStatistics<TimeSpan>>> AverageTimeSinceLastPasswordChangeForUser([FromBody] DateFilter filter)
        {
            var request = new AverageTimeSinceLastPasswordChangeForUserRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("AverageTimeSinceLastLoginForUser")]
        public async Task<ActionResult<NumberStatistics<TimeSpan>>> AverageTimeSinceLastLoginForUser([FromBody] DateFilter filter)
        {
            var request = new AverageTimeSinceLastLoginForUserRequest(filter);
            return await SendRequest(request);
        }
    }
}
