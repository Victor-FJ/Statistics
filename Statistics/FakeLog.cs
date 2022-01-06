using CC.Log.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics
{
    public class FakeLog<T> : ILog<T>
    {
        public void LogCritical(string message)
        {
            return;
        }

        public void LogCritical(Exception ex)
        {
            return;
        }

        public void LogCritical(Exception ex, string message)
        {
            return;
        }

        public void LogDebug(string message)
        {
            return;
        }

        public void LogError(string message)
        {
            return;
        }

        public void LogError(Exception ex)
        {
            return;
        }

        public void LogError(Exception ex, string message)
        {
            return;
        }

        public void LogInfo(string message)
        {
            return;
        }

        public void LogWarning(string message)
        {
            return;
        }
    }
}
