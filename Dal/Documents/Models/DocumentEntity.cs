using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Documents.Models
{
    public class DocumentEntity : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Guid ThirdPartyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string LegacyId { get; set; }
        public int TypeId { get; set; }
        public bool IsShareDoc { get; set; }

        public string StaticLink { get; set; }
        public bool StaticLinkEnabled { get; set; } = true;

        public Guid CopyOf { get; set; }
        public IEnumerable<Guid> CustomDocumentCategories { get; set; } = new List<Guid>();

    }
}
