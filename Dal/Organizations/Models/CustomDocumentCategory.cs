using System;

namespace DataAccess.Organizations.Models
{
    public class CustomDocumentCategory
    {
        public string Name { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();
    }
}