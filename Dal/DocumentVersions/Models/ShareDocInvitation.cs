using System;

namespace CC.DAL.Entities
{
    public class ShareDocInvitation
    {
        public string Id { get; set; }
        public string UserFullName { get; set; }
        public string Email { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsSendFinalDocEnabled { get; set; }
        public ShareDocInvitationStatus Status { get; set; }
    }
}
