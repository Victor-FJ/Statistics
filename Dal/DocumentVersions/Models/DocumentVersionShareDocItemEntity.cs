using System.Collections.Generic;
using CC.DAL.Entities;

namespace CC.Core.DocumentVersion
{
    public class DocumentVersionShareDocItemEntity
    {
        public List<DocumentVersionCommentItemEntity> Comments { get; set; } = new List<DocumentVersionCommentItemEntity>();
        public DocumentVersionActorItemEntity ExternalActor { get; set; }
        public List<ShareDocInvitation> Invitations { get; set; } = new List<ShareDocInvitation>();
    }
}
