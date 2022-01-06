using System;
using System.Collections.Generic;
using System.Linq;
using CC.Mediator;
using DataAccess.Statistics;
using DataAccess.DocumentVersions;

namespace Services.DocumentVersions.Requests.SplitBetweenTheTypeOfDocumentsInPercentage
{
    public class SplitBetweenTheTypeOfDocumentsInPercentageHandler : RequestSafeHandler<SplitBetweenTheTypeOfDocumentsInPercentageRequest, NumberStatistics<DocumentVersionTypePercentage>>
    {
        private readonly IDocumentVersionDataAccess _dataAccess = new DocumentVersionDataAccess();
        
        protected override NumberStatistics<DocumentVersionTypePercentage> Execute(SplitBetweenTheTypeOfDocumentsInPercentageRequest request)
        {
            //Validation
            //Do business logic
            //Get data from DataAccess
            List<DocumentVersionType> typesOfDocumentVersions = _dataAccess.SplitBetweenTheTypeOfDocumentsInPercentage(request.DateFilter);
            //Do more business logic and validation?
            var groupedTypesOfDocuments = typesOfDocumentVersions.GroupBy(x => x.GetTypeOfDocument())
                                                                 .Where(x => x.Key != DocumentVersionType.Type.None && x.Key != DocumentVersionType.Type.Multiple)
                                                                 .ToDictionary(x => x.Key, x => x.Count());

            //Build and return result
            NumberStatistics<DocumentVersionTypePercentage> statistics = new()
            {
                Filter = request.DateFilter,
                Result = new()
                {
                    Questionnarie = groupedTypesOfDocuments[DocumentVersionType.Type.Questionnarie],
                    ExternalLink = groupedTypesOfDocuments[DocumentVersionType.Type.ExternalLink],
                    FileUpload = groupedTypesOfDocuments[DocumentVersionType.Type.FileUpload]
                }
            };
            return statistics;
        }
    }
}
