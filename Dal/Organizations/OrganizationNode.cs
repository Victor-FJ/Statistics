using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Organizations
{
    public class OrganizationNode
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }

        public List<OrganizationNode> Nodes { get; set; }

        public OrganizationNode(Guid id, Guid? parentId)
        {
            Id = id;
            ParentId = parentId;
            Nodes = new List<OrganizationNode>();
        }

        public int CountAll() => Nodes.Sum(node => node.CountAll()) + 1;

        public override string ToString()
        {
            return $"Id:{Id}, ParentId:{ParentId}, Count:{Nodes.Count}";
        }
    }
}
