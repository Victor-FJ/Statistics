using System;
using System.Linq.Expressions;
using DataAccess.Extensions;
using DataAccess.Statistics;
using DataAccess.Tasks.Enum;
using DataAccess.Tasks.Models;

namespace DataAccess.Tasks
{
    public class TaskFilter : DateFilter
    {
        public TaskStatus Status { get; set; } = TaskStatus.Active;

        public Expression<Func<TaskEntity, bool>> GetFilter()
            => base.GetFilter<TaskEntity>().CombineWithAnd(task => task.Status == Status);
    }
}
