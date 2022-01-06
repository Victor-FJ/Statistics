using DataAccess.Tasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Organizations
{
    public class ComplianceLevelHandler
    {
        private const int ActiveForMoreThan = 30;
        private static readonly DateTime Current = DateTime.Now;

        public static DateTime ActiveForMoreThanDate { get; set; } = Current.AddDays(ActiveForMoreThan * -1);

        public static int ComplianceLevel(IEnumerable<TaskEntity> taskEntities)
        {
            int recentActiveTasksCount = taskEntities.Count(x => x.ActivationDate >= ActiveForMoreThanDate);
            int oldActiveTasksCount = taskEntities.Count(x => x.ActivationDate < ActiveForMoreThanDate);

            int score = (oldActiveTasksCount * 2) + (recentActiveTasksCount * 1);

            switch (score)
            {
                case 2:
                    return 94;
                case 3:
                    return 88;
                case 4:
                    return 82;
                case 5:
                    return 76;
                case 6:
                    return 70;
                case 7:
                    return 64;
                case 8:
                    return 58;
                case 9:
                    return 52;
                case 10:
                    return 46;
                case 11:
                    return 40;
                case 12:
                    return 34;
                case 13:
                    return 28;
                case 14:
                    return 22;
                case 15:
                    return 16;
                case 16:
                    return 10;
                case 17:
                    return 4;
                default:
                    if (score <= 1) return 100;
                    else return 1;
            }
        }
    }
}
