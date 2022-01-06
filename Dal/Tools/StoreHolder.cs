using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace DataAccess.Tools
{
    public static class StoreHolder
    {
        private static IDocumentStore _store = RavenClient.GetDevClient();
        public static IDocumentStore Instance => _store;

        public static IDocumentSession GetSession() => _store.OpenSession();
    }
}
