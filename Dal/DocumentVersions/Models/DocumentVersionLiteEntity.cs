using System;

namespace CC.Core.DocumentVersion
{
    public class DocumentVersionLiteEntity
    {
        public Guid CompanyId { get; set; }
        public Guid DocumentId { get; set; }
        public string Title { get; set; }
        public int VersionNumber { get; set; }
        public string StaticLink { get; set; }
    }
}
