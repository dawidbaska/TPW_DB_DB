using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Concurrent;
using System.Runtime.InteropServices.Marshalling;

namespace Dane
{
    public class Logger
    {
        ConcurrentQueue<string> cq = new ConcurrentQueue<string>();
        private string filePath;

        public void LogInfo(string message)
        {
            cq.Enqueue(message);
        }

        public Logger(string filePath)
        {
            this.filePath = filePath;
        }


        private void zapiszLogi() { 
            if (cq.Count > 0)
            {
                while (cq.TryDequeue(out string log))
                {
                    string jsonLog = JsonSerializer.Serialize(log);
                    using (StreamWriter file = new StreamWriter(filePath, true))
                    {
                        file.WriteLine(jsonLog);
                    }
                }
            }
        }


       
    }
}
