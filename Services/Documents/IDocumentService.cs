using System;
using DataAccess.Statistics;

namespace Services.Interfaces
{
    public interface IDocumentService
    {
        TotalStatistics<DateTime> TotalNumberOfDocuments(DateFilter dateFilter);
        TotalStatistics<DateTime> TotalNumberOfDocumentsWithThirdParty(DateFilter dateFilter);
        TotalStatistics<DateTime> TotalNumberOfSharedocDocuments(DateFilter dateFilter);
        NumberStatistics<int> AverageNumberOfDocumentsPrCompany(DateFilter dateFilter);
        TotalStatistics<int> MostUsedDocumentTypes(DateFilter dateFilter);
    }
}
