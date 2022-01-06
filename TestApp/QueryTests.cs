using System;
using DataAccess.Tasks.Enum;
using DataAccess.Statistics;
using Raven.Client.Documents.Session;
using System.Linq;
using Services;
using Raven.Client.Documents;
using DataAccess.Tasks.Models;
using Raven.Client.Documents.Linq;
using System.Linq.Expressions;
using DataAccess.Tools;
using System.Collections.Generic;
using DataAccess;
using DataAccess.Tasks;

namespace TestApp
{
    public static class QueryTests
    {
        public static void ExpressionTest()
        {
            using IDocumentSession session = StoreHolder.GetSession();


            DateTime from = new DateTime(2021, 05, 17, 0, 0, 0);
            DateTime to = new DateTime(2021, 05, 17, 23, 0, 0);
            TaskService taskThing = new TaskService(new TaskDataAccess());
            var taskTest1 = taskThing.TotalNumberOfTasks(new TaskFilter() { FromDate = from, ToDate = to } );

            //Test 1
            IRavenQueryable<TaskEntity> query = session.Query<TaskEntity>().Where(x => from < x.CreatedDate && x.CreatedDate < to && x.Status == TaskStatus.Active);
            var result = query.ToList();


            //Test 2
            Expression<Func<TaskEntity, bool>> func2 = x => from < x.CreatedDate && x.CreatedDate < to && x.Status == TaskStatus.Active;

            IRavenQueryable<TaskEntity> query2 = session.Query<TaskEntity>().Where(func2);
            var result2 = query.ToList();


            //Test 3 not gonna work i thougt but it does
            Expression<Func<TaskEntity, bool>> func3Date = x => from < x.CreatedDate && x.CreatedDate < to;

            Func<TaskEntity, bool> func3DateCompiled = func3Date.Compile();


            Expression<Func<TaskEntity, bool>> func3 = x => x.Status == TaskStatus.Active && func3DateCompiled(x);

            IRavenQueryable<TaskEntity> query3 = session.Query<TaskEntity>().Where(func3);
            var result3 = query.ToList();


            //Test 4
            Expression<Func<TaskEntity, bool>> func4Date = x => from < x.CreatedDate && x.CreatedDate < to;

            Expression<Func<TaskEntity, bool>> func4Status = x => x.Status == TaskStatus.Active;

            BinaryExpression finalFunc4 = Expression.AndAlso(func4Date.Body, func4Status.Body);

            Expression<Func<TaskEntity, bool>> finalFinalFunc4 = Expression.Lambda<Func<TaskEntity, bool>>(finalFunc4, func4Date.Parameters[0]);

            IRavenQueryable<TaskEntity> query4 = session.Query<TaskEntity>().Where(finalFinalFunc4);
            var result4 = query.ToList();
        }

        public static void QueryTest()
        {
            //QueryTest
            using IDocumentSession session = StoreHolder.GetSession();

            DateTime from = new DateTime(2021, 05, 17, 0, 0, 0);
            DateTime to = new DateTime(2021, 05, 17, 23, 0, 0);

            TaskService taskThing = new TaskService(new TaskDataAccess());
            var taskTest1 = taskThing.TotalNumberOfTasks(new TaskFilter() { FromDate = from, ToDate = to });



            Expression<Func<TaskEntity, bool>> func4Date = x => from < x.CreatedDate && x.CreatedDate < to;

            Expression<Func<TaskEntity, bool>> func4Status = x => x.Status == TaskStatus.Active;
            BinaryExpression finalFunc4 = Expression.AndAlso(func4Date.Body, func4Status.Body);
            Expression<Func<TaskEntity, bool>> filter = Expression.Lambda<Func<TaskEntity, bool>>(finalFunc4, func4Date.Parameters[0]);

            Expression<Func<TaskEntity, DateTime>> groupBy = x => x.CreatedDate.Date;

            Expression<Func<IGrouping<DateTime, TaskEntity>, object>> orderBy = x => x.Key;



            IRavenQueryable<TaskEntity> ravenQuery = session.Query<TaskEntity>();
            //.Where(filter);


            var test = ravenQuery
                 .GroupBy(x => x.CreatedDate.Date)
                 .Select(x => new
                 {
                     key = x.Key,
                     counts = x.Where(x => x.Status == TaskStatus.Active && from < x.CreatedDate && x.CreatedDate < to).Count()
                 })
                 .OrderBy(x => x.key);

            var test2 = test.ToList();


            //IQueryable<StatisticsEntry<DateTime>> query = ravenQuery
            //    .GroupBy(groupBy)
            //    .OrderBy(orderBy)
            //    .Select(x => new StatisticsEntry<DateTime>()
            //    {
            //        Key = x.Key,
            //        Count = x.Count()
            //    });

            //List<StatisticsEntry<DateTime>> entityEntries = query.ToList();
        }

        public static void QueryTest2()
        {
            using IDocumentSession session = StoreHolder.GetSession();

            DateTime from = new DateTime(2021, 05, 17, 0, 0, 0);
            DateTime to = new DateTime(2021, 05, 17, 23, 0, 0);

            from = DateTime.MinValue;
            to = DateTime.MaxValue;

            TaskService taskThing = new TaskService(new TaskDataAccess());
            var taskTest1 = taskThing.TotalNumberOfTasks(new TaskFilter() { FromDate = from, ToDate = to });


            //Test 1
            Expression<Func<TaskEntity, bool>> func4Date = x => from < x.CreatedDate && x.CreatedDate < to;

            Expression<Func<TaskEntity, bool>> func4Status = x => x.Status == TaskStatus.Active;

            BinaryExpression finalFunc4 = Expression.AndAlso(func4Date.Body, func4Status.Body);
            Expression<Func<TaskEntity, bool>> filter = Expression.Lambda<Func<TaskEntity, bool>>(finalFunc4, func4Date.Parameters[0]);


            Expression<Func<TaskEntity, DateTime>> groupBy = x => x.CreatedDate.Date;

            Expression<Func<IGrouping<DateTime, TaskEntity>, object>> orderBy = x => x.Key;

            Expression<Func<TaskEntity, bool>> filter2 = GetDateFilter<TaskEntity>(from, to);

            IRavenQueryable<DateTime> ravenQuery = session.Query<TaskEntity>()
            .Where(GetDateFilter<TaskEntity>(from, to))
            .Select(groupBy);

            var test = ravenQuery.ToList();

            List<StatisticsEntry<DateTime>> entityEntries = test
                .GroupBy(x => x)
                .OrderBy(x => x.Key)
                .Select(x => new StatisticsEntry<DateTime>()
                {
                    Key = x.Key,
                    Count = x.Count()
                }).ToList();



        }

        private static Expression<Func<T, bool>> GetDateFilter<T>(DateTime from, DateTime to) where T : BaseEntity => x => from < x.CreatedDate && x.CreatedDate < to;
    }
}
