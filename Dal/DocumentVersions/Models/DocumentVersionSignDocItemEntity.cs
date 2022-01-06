using System;
using System.Collections.Generic;
using System.Linq;

namespace CC.Core.DocumentVersion
{
    public class DocumentVersionSignDocItemEntity
    {
        public List<DocumentVersionSignDocActorItemEntity> Signers { get; set; } = new List<DocumentVersionSignDocActorItemEntity>();
        public bool MandatoryLogin { get; set; }
        public bool SendMail { get; set; }
        public string Culture { get; set; }
        public string ObjectKey { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddMonths(1);
        public IEnumerable<Guid> AttachmentsToSign { get; set; } = new List<Guid>();
        public string SignOrderId { get; set; }
        public string SignDocumentReference { get; set; }
        public List<DocumentVersionSignAgreementItemEntity> SignAgreements { get; set; } = new List<DocumentVersionSignAgreementItemEntity>();

        public bool SendAttachements { get { return AttachmentsToSign.Any(); } }

        public Guid CancelledBy { get; set; }
        public string CancelReason { get; set; }
    }
}
