using DataAccess.Organizations.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Organizations.Models
{
    public class OrganizationEntity : BaseEntity
    {
        public int? MetaId { get; set; }
        public Guid? ParentId { get; set; }
        public List<Guid> ParentIds { get; set; } = new List<Guid>();
        public List<CompanyRoleModel> Roles { get; set; } = new List<CompanyRoleModel>();

        public OrganizationType Type { get; set; }

        public string Name { get; set; }
        public string Cvr { get; set; }

        public OrganizationAddressItemEntityModel Address { get; set; }

        public int? IndustryId { get; set; }
        public int? CategoryId { get; set; }
        public int? ProcessingActivityId { get; set; }
        public string TimeZone { get; set; }

        public Guid? ContactPersonId { get; set; }
        public Guid? DataProtectionOfficerId { get; set; }

        public bool IsDemoMode { get; set; }
        public bool IsTest { get; set; }
        public bool AllowWoy { get; set; }
        public bool AllowSign { get; set; }
        public bool IsSubProcessor { get; set; }

        public string Logo { get; set; }
        public string Host { get; set; }

        public IEnumerable<CustomDocumentCategory> CustomDocumentCategories { get; set; } =
            new List<CustomDocumentCategory>();

    }
}
