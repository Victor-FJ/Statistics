using System;
using System.Collections.Generic;
using System.Linq;
using CC.DAL.Entities;
using DataAccess;

namespace CC.Core.DocumentVersion
{
    public class DocumentVersionEntity : BaseEntity
    {
        public Guid DocumentId { get; set; }
        public Guid CompanyId { get; set; }

        public int Version { get; set; }

        public DocumentVersionActorItemEntity Owner { get; set; }

        public DocumentVersionShareDocItemEntity ShareDoc { get; set; }
        public DocumentVersionSignDocItemEntity SignDoc { get; set; }
       
        public bool QuestionnaireSkipped { get; set; }

        public List<DocumentVersionStateItemEntity> States { get; set; } = new List<DocumentVersionStateItemEntity>();
        public List<DocumentVersionCommentItemEntity> Comments { get; set; } = new List<DocumentVersionCommentItemEntity>();
        public List<DocumentVersionAnswerItemEntity> Answers { get; set; } = new List<DocumentVersionAnswerItemEntity>();
        public List<DocumentVersionAnswerItemEntity> ExternalAnswers { get; set; } = new List<DocumentVersionAnswerItemEntity>();
        public List<Guid> Attachments { get; set; } = new List<Guid>();
        public List<Guid> SignDocumentAttachments { get; set; } = new List<Guid>();
        public List<int> TimeTakenPerStep { get; set; } = new List<int>();

        public List<DocumentVersionEvent> Events { get; set; } = new List<DocumentVersionEvent>();

        public DocumentVersionStateItemEntity CurrentState => States.OrderByDescending(x => x.ChangedDate).FirstOrDefault();

        public Guid? FileInfo { get; set; }
        public Guid? FileDocId { get; set; }

        public bool PdfGenerated { get; set; }
        public bool DocGenerated { get; set; }
        public string Url { get; set; }
    }
}
