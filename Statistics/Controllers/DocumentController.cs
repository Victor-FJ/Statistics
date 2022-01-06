using Microsoft.AspNetCore.Mvc;
using System;
using DataAccess.Statistics;
using Services.Documents.Requests.TotalNumberOfDocuments;
using Services.Documents.Requests.TotalNumberOfDocumentsWithThirdParty;
using Services.Documents.Requests.TotalNumberOfSharedocDocuments;
using Services.Documents.Requests.AverageNumberOfDocumentsPrCompany;
using Services.Documents.Requests.MostUsedDocumentTypes;
using System.Threading.Tasks;
using Services.Documents.Requests.TotalNumberOfSharedocDocumentsWithThirdParty;

namespace Statistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : NswagController
    {
        [HttpGet("TotalNumberOfDocuments")]
        public async Task<ActionResult<TotalStatistics<DateTime>>> TotalNumberOfDocuments([FromBody] DateFilter filter)
        {
            var request = new TotalNumberOfDocumentsRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("TotalNumberOfDocumentsWithThirdParty")]
        public async Task<ActionResult<TotalStatistics<DateTime>>> TotalNumberOfDocumentsWithThirdParty([FromBody] DateFilter filter)
        {
            var request = new TotalNumberOfDocumentsWithThirdPartyRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("TotalNumberOfSharedocDocuments")]
        public async Task<ActionResult<TotalStatistics<DateTime>>> TotalNumberOfSharedocDocuments([FromBody] DateFilter filter)
        {
            var request = new TotalNumberOfSharedocDocumentsRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("TotalNumberOfSharedocDocumentsWithThirdParty")]
        public async Task<ActionResult<TotalStatistics<DateTime>>> TotalNumberOfSharedocDocumentsWithThirdParty([FromBody] DateFilter filter)
        {
            var request = new TotalNumberOfSharedocDocumentsWithThirdPartyRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("AverageNumberOfDocumentsPrCompany")]
        public async Task<ActionResult<NumberStatistics<int>>> AverageNumberOfDocumentsPrCompany([FromBody] DateFilter filter)
        {
            var request = new AverageNumberOfDocumentsPrCompanyRequest(filter);
            return await SendRequest(request);
        }

        [HttpGet("MostUsedDocumentTypes")]
        public async Task<ActionResult<TotalStatistics<int>>> MostUsedDocumentTypes([FromBody] DateFilter filter)
        {
            var request = new MostUsedDocumentTypesRequest(filter);
            return await SendRequest(request);
        }
    }
}
