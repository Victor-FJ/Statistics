using CC.Storage.RavenDB;
using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using Raven.Client.Exceptions.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tools
{
    public static class RavenClient
    {
        //This class was from ComplyCloud to access their database.
        //It included urls and database names and has theirfore been emptied.

        public static IDocumentStore GetDevClient()
        {
            throw new NotImplementedException();
        }

        public static IDocumentStore GetProductionClient()
        {
            throw new NotImplementedException();
        }
    }
}
