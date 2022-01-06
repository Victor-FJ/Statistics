using System;
using System.Collections.Generic;

namespace CC.Core.DocumentVersion
{
    public class DocumentVersionAnswerItemEntity
    {
        public Guid AuthorUserID { get; set; } = Guid.Empty;
        public Guid UserId { get; set; }

        public string Type { get; set; }
        public string FieldId { get; set; }
        public int UmbracoFieldId { get; set; }
        public string Value { get; set; } = string.Empty;
        public string Mask { get; set; } = string.Empty;
        public string NoSelectionText { get; set; } = string.Empty;
        public bool ShowAsList { get; set; }
        public bool DontMerge { get; set; }
        public bool IsEnabled { get; set; }

        public List<DocumentVersionSelectedValueItemEntity> SelectedValues { get; set; } = new List<DocumentVersionSelectedValueItemEntity>();
    }
}
