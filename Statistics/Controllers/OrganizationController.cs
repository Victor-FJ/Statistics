using CC.Mediator;
using DataAccess.Organizations;
using DataAccess.Statistics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using Services.Organizations.Requests.AverageComplianceLevelForCompanies;
using Services.Organizations.Requests.AverageNumberOfCompaniesInTheSameGroup;
using Services.Organizations.Requests.AverageNumberOfRelatedThirdPartyOrganizationsForACompany;
using Services.Organizations.Requests.TotalNumberOfCompanies;
using Services.Organizations.Requests.TotalNumberOfOrganizations;
using Services.Organizations.Requests.TotalNumberOfThirdParties;
using Services.Organizations.Requests.TotalNumberOfThirdPartiesCreatedFromTheMetaLayer;
using System;
using System.Threading.Tasks;

namespace Statistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : NswagController
    {
        [HttpGet("TotalNumberOfOrganizations")]
        public async Task<ActionResult<TotalStatistics<DateTime>>> TotalNumberOfOrganizations([FromBody] DateFilter filter)
        {
            var request = new TotalNumberOfOrganizationsRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("TotalNumberOfCompanies")]
        public async Task<ActionResult<TotalStatistics<DateTime>>> TotalNumberOfCompanies([FromBody] DateFilter filter)
        {
            var request = new TotalNumberOfCompaniesRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("TotalNumberOfThirdParties")]
        public async Task<ActionResult<TotalStatistics<DateTime>>> TotalNumberOfThirdParties([FromBody] DateFilter filter)
        {
            var request = new TotalNumberOfThirdPartiesRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("AverageNumberOfRelatedThirdPartyOrganizationsForACompany")]
        public async Task<ActionResult<NumberStatistics<int>>> AverageNumberOfRelatedThirdPartyOrganizationsForACompany([FromBody] DateFilter filter)
        {
            var request = new AverageNumberOfRelatedThirdPartyOrganizationsForACompanyRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("AverageNumberOfCompaniesInTheSameGroup")]
        public async Task<ActionResult<NumberStatistics<int>>> AverageNumberOfCompaniesInTheSameGroup([FromBody] DateFilter filter)
        {
            var request = new AverageNumberOfCompaniesInTheSameGroupRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("TotalNumberOfThirdPartiesCreatedFromTheMetaLayer")]
        public async Task<ActionResult<TotalStatistics<DateTime>>> TotalNumberOfThirdPartiesCreatedFromTheMetaLayer([FromBody] DateFilter filter)
        {
            var request = new TotalNumberOfThirdPartiesCreatedFromTheMetaLayerRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("AverageComplianceLevelForCompanies")]
        public async Task<ActionResult<NumberStatistics<int>>> AverageComplianceLevelForCompanies([FromBody] DateFilter filter)
        {
            var request = new AverageComplianceLevelForCompaniesRequest(filter);
            return await SendRequest(request);
        }
    }
}
