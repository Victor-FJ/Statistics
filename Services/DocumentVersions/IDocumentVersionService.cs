using DataAccess.DocumentVersions;
using DataAccess.Statistics;
using System;

namespace Services.Interfaces
{
    public interface IDocumentVersionService
    {
        public TotalStatistics<DateTime> TotalNumberOfDocumentVersions(DateFilter dateFilter);

        public NumberStatistics<int> AverageNumberOfVersionsPrDocument(DateFilter dateFilter);

        public NumberStatistics<DocumentVersionTypePercentage> SplitBetweenTheTypeOfDocumentsInPercentage(DateFilter dateFilter);
    }
}
