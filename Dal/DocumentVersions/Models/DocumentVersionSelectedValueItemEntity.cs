namespace CC.Core.DocumentVersion
{
    public class DocumentVersionSelectedValueItemEntity
    {
        public string FieldId { get; set; }
        public int UmbracoFieldId { get; set; }
        public string Mask { get; set; }
        public string Value { get; set; }
        public bool IsChecked { get; set; }
        public bool DontMerge { get; set; }
    }
}
