using CC.Core.DocumentVersion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DocumentVersions
{
    public class DocumentVersionType
    {
        public enum Type
        {
            None,
            Multiple,
            Questionnarie,
            ExternalLink,
            FileUpload,
        }


        public List<DocumentVersionAnswerItemEntity> Answers { get; set; }
        public bool QuestionnaireSkipped { get; set; }
        public string Url { get; set; }
        public Guid? FilePdfId { get; set; }

        public Type GetTypeOfDocument()
        {
            bool quistion = Answers?.Count > 0 && !QuestionnaireSkipped;
            bool url = !string.IsNullOrEmpty(Url) && QuestionnaireSkipped;
            bool file = FilePdfId != null && FilePdfId != Guid.Empty && QuestionnaireSkipped;

            int howManyTrue = (quistion ? 1 : 0) + (url ? 1 : 0) + (file ? 1 : 0);
            if (howManyTrue > 1)
                return Type.Multiple;

            return quistion ? Type.Questionnarie
                 : url ? Type.ExternalLink
                 : file ? Type.FileUpload
                 : Type.None;
        }
    }
}
