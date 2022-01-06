using DataAccess.Statistics;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Tools
{   
    public abstract class GeneralDataAccess<T> where T : BaseEntity
    {
        protected IDocumentStore Store { get; set; } = StoreHolder.Instance;


        protected List<TKey> GetEntities<TKey>(Expression<Func<T, bool>> filter,
                                               Expression<Func<T, TKey>> selector)
        {
            using IDocumentSession session = Store.OpenSession();

            IRavenQueryable<TKey> query = session.Query<T>()
                .Where(filter)
                .Select(selector);

            return query.ToList();
        }


        protected List<StatisticsEntry<TKey>> TotalNumberOfEntity<TKey>(Expression<Func<T, bool>> filter,
                                                                        Expression<Func<T, TKey>> groupBySelector,
                                                                        Func<IGrouping<TKey, TKey>, object> orderBySelector = null)
        {
            Func<IGrouping<TKey, TKey>, object> defaultOrderBySelector = x => x.Key;

            List<StatisticsEntry<TKey>> entityEntries = GetEntities(filter, groupBySelector)
                .GroupBy(x => x)
                .OrderBy(orderBySelector ?? defaultOrderBySelector)
                .Select(x => new StatisticsEntry<TKey>()
                {
                    Key = x.Key,
                    Count = x.Count()
                }).ToList();

            return entityEntries;
        }

        protected List<StatisticsEntry<DateTime>> TotalNumberOfEntity(Expression<Func<T, bool>> filter,
                                                                      Func<IGrouping<DateTime, DateTime>, object> orderBySelector = null)
            => TotalNumberOfEntity(filter, x => x.CreatedDate.Date, orderBySelector);


        protected double AverageNumberOfEntityPr<TKey>(Expression<Func<T, bool>> filter, 
                                                       Expression<Func<T, TKey>> groupBySelector)
        {
            double average = GetEntities(filter, groupBySelector)
                .GroupBy(x => x)
                .Average(x => x.Count());

            return average;
        }

        protected int NumberOfEntity(Expression<Func<T, bool>> filter)
        {
            using IDocumentSession session = Store.OpenSession();


            IRavenQueryable<T> query = session.Query<T>();

            int count = query.Count(filter);
            
            return count;
        }
    }
}
