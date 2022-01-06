using DataAccess.Statistics;
using System;
using System.Collections.Generic;

namespace DataAccess.Documents
{
    public interface IDocumentDataAccess
    {
        List<StatisticsEntry<DateTime>> TotalNumberOfDocuments(DateFilter dateFilter);
        List<StatisticsEntry<DateTime>> TotalNumberOfDocumentsWithThirdParty(DateFilter dateFilter);
        List<StatisticsEntry<DateTime>> TotalNumberOfSharedocDocuments(DateFilter dateFilter);
        List<StatisticsEntry<DateTime>> TotalNumberOfSharedocDocumentsWithThirdParty(DateFilter dateFilter);
        double AverageNumberOfDocumentsPrCompany(DateFilter dateFilter);
        List<StatisticsEntry<int>> MostUsedDocumentTypes(DateFilter dateFilter);
    }
}
