using DataAccess.Tasks.Enum;
using System;
using System.Collections.Generic;

namespace DataAccess.Tasks.Models
{
    public class TaskEntity : BaseEntity
    {
        public Guid? ParentId { get; set; }
        public Guid CompanyId { get; set; }
        public int TaskDefinitionId { get; set; }

        public TaskFrequency? Frequency { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ActivationDate { get; set; }
        public Guid? AssignedUserId { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Planned;

        public TaskAction Action { get; set; }
        public Dictionary<string, string> ActionParams { get; set; } = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public Dictionary<string, string> Title { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Type { get; set; } = new Dictionary<string, string>();
        public string Description { get; set; }

        public string Reason { get; set; }
        public string NumberOfte { get; set; }

        public Guid? PdfFileId { get; set; }
        public string StaticLink { get; set; }

        public IList<Guid> Subscribers { get; set; } = new List<Guid>();
    }
}
