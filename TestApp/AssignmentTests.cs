using DataAccess;
using DataAccess.Documents;
using DataAccess.Documents.Models;
using DataAccess.Organizations;
using DataAccess.Statistics;
using DataAccess.Tasks;
using DataAccess.Tasks.Enum;
using DataAccess.Tasks.Models;
using DataAccess.Tools;
using Raven.Client.Documents.Session;
using Services;
using System;
using System.Linq;

namespace TestApp
{
    public static class AssignmentTests
    {
        public static void TestTask()
        {
            TaskDataAccess taskThing = new TaskDataAccess();
            var test = taskThing.TotalNumberOfTasks();

            //TaskService taskThing = new TaskService(new TaskDataAccess());
            //var taskTest1 = taskThing.TotalNumberOfTasks(new TaskFilter());
            //var taskTest2 = taskThing.AverageNumberOfTasksPrCompany(new TaskFilter());
            //var taskTest3 = taskThing.NumberOfDedicatedTasks(new TaskFilter());
        }

        public static void TestDocument()
        {
            using IDocumentSession session = StoreHolder.GetSession();

            var result = session.Query<DocumentEntity>().ToList();
            DocumentService documentData = new DocumentService(new DocumentDataAccess());

            //Document date test
            DateTime from = new DateTime(2021, 05, 17, 0, 0, 0);
            DateTime to = new DateTime(2021, 05, 17, 23, 0, 0);

            //from = DateTime.MinValue;
            //to = DateTime.MaxValue;

            var docTest1Ex = result.Where(x => from < x.CreatedDate && x.CreatedDate < to).ToList();


            var docTest1 = documentData.TotalNumberOfDocuments(new DateFilter() { FromDate = from, ToDate = to });



            //Document test average
            var docTest2Ex = result.GroupBy(x => x.CompanyId).ToList();

            int doc2 = docTest2Ex.Sum(x => x.Count() * -1);

            double average = doc2 / docTest1Ex.Count();

            var docTest2 = documentData.AverageNumberOfDocumentsPrCompany(new DateFilter());



            var docTest3Ex = result.GroupBy(x => x.TypeId).OrderBy(x => x.Count());
            var docTest3 = documentData.MostUsedDocumentTypes(new DateFilter());
        }

        public static void TestOrganization()
        {
            DateFilter filter = new DateFilter();

            OrganizationService organizationService = new OrganizationService(new OrganizationDataAccess());
            var resultEx = organizationService.AverageComplianceLevelForCompanies(filter);
        }
    }
}
