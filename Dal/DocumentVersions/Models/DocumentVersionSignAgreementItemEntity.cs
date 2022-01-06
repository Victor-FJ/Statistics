using System;

namespace CC.Core.DocumentVersion
{
    public class DocumentVersionSignAgreementItemEntity
    {
        public int DocumentId { get; set; }
        public Guid FileId { get; set; }
        public string AgreementId { get; set; }
        public bool IsAttachment { get; set; }
    }
}
