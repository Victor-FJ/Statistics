using DataAccess.Statistics;
using System;
using System.Collections.Generic;

namespace DataAccess.DocumentVersions
{
    public interface IDocumentVersionDataAccess
    {
        public List<StatisticsEntry<DateTime>> TotalNumberOfDocumentVersions(DateFilter dateFilter);

        public double AverageNumberOfVersionsPrDocument(DateFilter dateFilter);

        public List<DocumentVersionType> SplitBetweenTheTypeOfDocumentsInPercentage(DateFilter dateFilter);
    }
}
