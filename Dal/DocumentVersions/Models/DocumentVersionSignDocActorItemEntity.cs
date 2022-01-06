using System;

namespace CC.Core.DocumentVersion
{
    public class DocumentVersionSignDocActorItemEntity
    {
        public Guid? UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string SignType { get; set; }

        public bool HasApproved { get; set; }
        public DateTime? DecisionDate { get; set; } = null;
        public string DecisionComment { get; set; }
    }
}
