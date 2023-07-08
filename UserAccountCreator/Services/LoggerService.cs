using System;
using System.Collections.Generic;
using System.Linq;
using UserAccountCreator.Models;

namespace UserAccountCreator.Services
{
    public class LoggerService
    {
        public event Action<Log> AddedLog;

        private Stack<Log> logs = new Stack<Log>();

        public void Print(string message)
        {
            var log = new Log()
            {
                CreationTime = DateTime.Now,
                Message = message
            };

            logs.Push(log);

            AddedLog?.Invoke(log);
        }

        public List<Log> GetAllLogs()
        {
            return logs.ToList();
        }
    }
}
