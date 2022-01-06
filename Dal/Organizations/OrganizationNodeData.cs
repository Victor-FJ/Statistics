using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Organizations
{
    public class OrganizationNodeData
    {
        public string Id { get; set; }

        public Guid? ParentId { get; set; }

        #region Constructors

        public OrganizationNodeData()
        {

        }
        public OrganizationNodeData(string id, Guid? parentId)
        {
            Id = id;
            ParentId = parentId;
        }

        #endregion

        public OrganizationNode ToNode()
            => new OrganizationNode(Guid.Parse(Id), ParentId);
    }
}
