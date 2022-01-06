using CC.DAL.Entities;
using System;

namespace CC.Core.DocumentVersion
{
    public class DocumentVersionShareDocInvitationItemEntity
    {
        public string Id { get; set; }
        public string UserFullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsSendFinalDocEnabled { get; set; }
        public ShareDocInvitationStatus Status { get; set; }
    }
}
