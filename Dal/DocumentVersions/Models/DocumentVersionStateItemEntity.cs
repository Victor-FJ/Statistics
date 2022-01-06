using System;

namespace CC.Core.DocumentVersion
{
    public class DocumentVersionStateItemEntity
    {
        public Guid UserId { get; set; }
        public Guid DocumentStateId { get; set; }
        public DateTime ChangedDate { get; set; } = DateTime.UtcNow;
    }
}
