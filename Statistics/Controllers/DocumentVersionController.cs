using CC.Mediator;
using DataAccess.DocumentVersions;
using DataAccess.Statistics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DocumentVersions.Requests.AverageNumberOfVersionsPrDocument;
using Services.DocumentVersions.Requests.SplitBetweenTheTypeOfDocumentsInPercentage;
using Services.DocumentVersions.Requests.TotalNumberOfDocumentVersions;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentVersionController : NswagController
    {
        [HttpGet("TotalNumberOfDocumentVersions")]
        public async Task<ActionResult<TotalStatistics<DateTime>>> TotalNumberOfDocumentVersions([FromBody] DateFilter filter)
        {
            var request = new TotalNumberOfDocumentVersionsRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("AverageNumberOfVersionsPrDocument")]
        public async Task<ActionResult<NumberStatistics<int>>> AverageNumberOfVersionsPrDocument([FromBody] DateFilter filter)
        {
            var request = new AverageNumberOfVersionsPrDocumentRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("SplitBetweenTheTypeOfDocumentsInPercentage")]
        public async Task<ActionResult<NumberStatistics<DocumentVersionTypePercentage>>> SplitBetweenTheTypeOfDocumentsInPercentage([FromBody] DateFilter filter)
        {
            var request = new SplitBetweenTheTypeOfDocumentsInPercentageRequest(filter);
            return await SendRequest(request);
        }
    }
}
