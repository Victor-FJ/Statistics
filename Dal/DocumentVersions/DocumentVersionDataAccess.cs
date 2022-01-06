using CC.Core.DocumentVersion;
using DataAccess.Statistics;
using DataAccess.Tools;
using System;
using System.Collections.Generic;

namespace DataAccess.DocumentVersions
{
    public class DocumentVersionDataAccess : GeneralDataAccess<DocumentVersionEntity>, IDocumentVersionDataAccess
    {
        public List<StatisticsEntry<DateTime>> TotalNumberOfDocumentVersions(DateFilter dateFilter) 
            => TotalNumberOfEntity(dateFilter.GetFilter<DocumentVersionEntity>());

        public double AverageNumberOfVersionsPrDocument(DateFilter dateFilter) 
            => AverageNumberOfEntityPr(dateFilter.GetFilter<DocumentVersionEntity>(), x => x.DocumentId);


        public List<DocumentVersionType> SplitBetweenTheTypeOfDocumentsInPercentage(DateFilter dateFilter)
            => GetEntities(dateFilter.GetFilter<DocumentVersionEntity>(), x => new DocumentVersionType()
            {
                Answers = x.Answers,
                QuestionnaireSkipped = x.QuestionnaireSkipped,
                Url = x.Url,
                FilePdfId = x.FileInfo
            });
    }
}
