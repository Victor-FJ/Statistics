using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Extensions;
using DataAccess.Statistics;
using DataAccess.Tasks.Enum;
using DataAccess.Tasks.Models;
using DataAccess.Tools;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;

namespace DataAccess.Tasks
{
    public class TaskDataAccess : GeneralDataAccess<TaskEntity>, ITaskDataAccess
    {
        public List<StatisticsEntry<DateTime>> TotalNumberOfTasks(TaskFilter taskFilter) 
            => TotalNumberOfEntity(taskFilter.GetFilter());

        public List<StatisticsEntry<DateTime>> TotalNumberOfTasks()
        {
            using IDocumentSession session = RavenClient.GetDevClient().OpenSession();

            var entries = session.Query<TaskEntity>()
                //.ToList()
                .Where(x => x.Status == TaskStatus.Active)
                .GroupBy(x => x.CreatedDate.Date)
                .Select(x => new StatisticsEntry<DateTime>()
                {
                    Key = x.Key,
                    Count = x.Count()
                }).ToList();

            return entries;
        }

        public double AverageNumberOfTasksPrCompany(TaskFilter taskFilter) 
            => AverageNumberOfEntityPr(taskFilter.GetFilter(), x => x.CompanyId);

        public int NumberOfDedicatedTasks(TaskFilter taskFilter) 
            => NumberOfEntity(taskFilter.GetFilter().CombineWithAnd(task => task.AssignedUserId != null && task.AssignedUserId != Guid.Empty));

        public int NumberOfCustomTasks(TaskFilter taskFilter) 
            => NumberOfEntity(taskFilter.GetFilter().CombineWithAnd(task => task.TaskDefinitionId == 0));
    }
}
