using System;

namespace CC.Core.DocumentVersion
{
    public class DocumentVersionActorItemEntity
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }

        public bool HasApproved { get; set; }
        public DateTime? DecisionDate { get; set; }
        public string DecisionComment { get; set; }
        public string SignType { get; set; }
    }
}
