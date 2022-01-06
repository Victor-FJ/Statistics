using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Documents.Models;
using DataAccess.Extensions;
using DataAccess.Statistics;
using DataAccess.Tools;

namespace DataAccess.Documents
{
    public class DocumentDataAccess : GeneralDataAccess<DocumentEntity>, IDocumentDataAccess
    {
        public List<StatisticsEntry<DateTime>> TotalNumberOfDocuments(DateFilter dateFilter)
            => TotalNumberOfEntity(dateFilter.GetFilter<DocumentEntity>());

        public List<StatisticsEntry<DateTime>> TotalNumberOfDocumentsWithThirdParty(DateFilter dateFilter) 
            => TotalNumberOfEntity(dateFilter.GetFilter<DocumentEntity>().CombineWithAnd(document => document.ThirdPartyId != Guid.Empty));

        public List<StatisticsEntry<DateTime>> TotalNumberOfSharedocDocuments(DateFilter dateFilter) 
            => TotalNumberOfEntity(dateFilter.GetFilter<DocumentEntity>().CombineWithAnd(document => document.IsShareDoc));

        public List<StatisticsEntry<DateTime>> TotalNumberOfSharedocDocumentsWithThirdParty(DateFilter dateFilter)
            => TotalNumberOfEntity(dateFilter.GetFilter<DocumentEntity>().CombineWithAnd(document => document.ThirdPartyId != Guid.Empty && document.IsShareDoc));

        public double AverageNumberOfDocumentsPrCompany(DateFilter dateFilter) 
            => AverageNumberOfEntityPr(dateFilter.GetFilter<DocumentEntity>(), x => x.CompanyId);

        public List<StatisticsEntry<int>> MostUsedDocumentTypes(DateFilter dateFilter) 
            => TotalNumberOfEntity(dateFilter.GetFilter<DocumentEntity>(), x => x.TypeId, x => x.Count() * -1);
    }
}
