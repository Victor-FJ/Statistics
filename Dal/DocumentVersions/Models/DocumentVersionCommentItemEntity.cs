using System;

namespace CC.Core.DocumentVersion
{
    public class DocumentVersionCommentItemEntity
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public Guid CreatedBy { get; set; }

        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; }

        public Guid ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public bool IsDeactivated { get; set; }

        public DateTime? DeactivatedDate { get; set; }
    }
}
