using DataAccess.DocumentVersions;
using DataAccess.Statistics;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class DocumentVersionService : IDocumentVersionService
    {
        private readonly IDocumentVersionDataAccess _documentVersionDataAccess;

        public DocumentVersionService(IDocumentVersionDataAccess documentVersionDataAccess)
        {
            _documentVersionDataAccess = documentVersionDataAccess;
        }

        public TotalStatistics<DateTime> TotalNumberOfDocumentVersions(DateFilter dateFilter)
        {
            List<StatisticsEntry<DateTime>> entries = _documentVersionDataAccess.TotalNumberOfDocumentVersions(dateFilter);

            TotalStatistics<DateTime> statistics = new(dateFilter, entries);
            return statistics;
        }

        public NumberStatistics<int> AverageNumberOfVersionsPrDocument(DateFilter dateFilter)
        {
            double average = _documentVersionDataAccess.AverageNumberOfVersionsPrDocument(dateFilter);

            NumberStatistics<int> statistics = new(dateFilter, (int)Math.Round(average));
            return statistics;
        }

        public NumberStatistics<DocumentVersionTypePercentage> SplitBetweenTheTypeOfDocumentsInPercentage(DateFilter dateFilter)
        {
            List<DocumentVersionType> typesOfDocumentVersions = _documentVersionDataAccess.SplitBetweenTheTypeOfDocumentsInPercentage(dateFilter);

            var groupedTypesOfDocuments = typesOfDocumentVersions.GroupBy(x => x.GetTypeOfDocument())
                                                                 .Where(x => x.Key != DocumentVersionType.Type.None && x.Key != DocumentVersionType.Type.Multiple)
                                                                 .ToDictionary(x => x.Key, x => x.Count());

            //double sum = groupedTypesOfDocuments.Sum(x => x.Value);

            NumberStatistics<DocumentVersionTypePercentage> statistics = new()
            {
                Filter = dateFilter,
                Result = new()
                {
                    Questionnarie = groupedTypesOfDocuments[DocumentVersionType.Type.Questionnarie], // / sum,
                    ExternalLink = groupedTypesOfDocuments[DocumentVersionType.Type.ExternalLink], // / sum,
                    FileUpload = groupedTypesOfDocuments[DocumentVersionType.Type.FileUpload] // / sum
                }
            };

            return statistics;
        }
    }
}
