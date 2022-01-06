using System;
using System.Collections.Generic;
using DataAccess.Documents;
using DataAccess.Statistics;
using Services.Interfaces;

namespace Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentDataAccess _documentDataAccess;

        public DocumentService(IDocumentDataAccess documentDataAccess)
        {
            _documentDataAccess = documentDataAccess;
        }
        public TotalStatistics<DateTime> TotalNumberOfDocuments(DateFilter dateFilter)
        {
            List<StatisticsEntry<DateTime>> entries = _documentDataAccess.TotalNumberOfDocuments(dateFilter);

            TotalStatistics<DateTime> statistics = new(dateFilter, entries);
            return statistics;
        }

        public TotalStatistics<DateTime> TotalNumberOfDocumentsWithThirdParty(DateFilter dateFilter)
        {
            List<StatisticsEntry<DateTime>> entries = _documentDataAccess.TotalNumberOfDocumentsWithThirdParty(dateFilter);

            TotalStatistics<DateTime> statistics = new(dateFilter, entries);
            return statistics;
        }

        public TotalStatistics<DateTime> TotalNumberOfSharedocDocuments(DateFilter dateFilter)
        {
            List<StatisticsEntry<DateTime>> entries = _documentDataAccess.TotalNumberOfSharedocDocuments(dateFilter);

            TotalStatistics<DateTime> statistics = new(dateFilter, entries);
            return statistics;
        }

        public NumberStatistics<int> AverageNumberOfDocumentsPrCompany(DateFilter dateFilter)
        {
            double average = _documentDataAccess.AverageNumberOfDocumentsPrCompany(dateFilter);

            NumberStatistics<int> statistics = new(dateFilter, (int)Math.Round(average));
            return statistics;
        }

        public TotalStatistics<int> MostUsedDocumentTypes(DateFilter dateFilter)
        {
            List<StatisticsEntry<int>> entries = _documentDataAccess.MostUsedDocumentTypes(dateFilter);

            TotalStatistics<int> statistics = new(dateFilter, entries);
            return statistics;
        }
    }
}
