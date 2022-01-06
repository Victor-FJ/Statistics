using System;

namespace CC.DAL.Entities
{
    public class DocumentVersionEvent
    {
        public string SourceInvitationId { get; set; }
        public string DestinationInvitationId { get; set; }
        public DocumentVersionEventType Type { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}
