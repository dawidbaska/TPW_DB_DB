using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Concurrent;
using System.Runtime.InteropServices.Marshalling;
using System.Diagnostics;
using System.Data.Common;
using System.Reflection;

namespace Dane
{
    public class Logger
    {
        ConcurrentQueue<string> cq = new ConcurrentQueue<string>();
        private string filePath;

        public void Dodaj_logi(string wiadomosc)
        {
            cq.Enqueue(wiadomosc);
        }

        public Logger(string filePath)
        {
            this.filePath = filePath;
            StworzPlik();
        }

        private void StworzPlik()
        {
            string folder = Directory.GetCurrentDirectory();
            string wzgledna = @"..\..\..\..\Logi\";
            string cala = Path.Combine(folder, wzgledna, this.filePath);
            this.filePath = cala;
            string directoryPath = Path.GetDirectoryName(cala);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            if (!File.Exists(this.filePath))
            {
                using (FileStream fs = File.Create(this.filePath))
                {
                }
            }
        }


        public void zapiszLogi() { 
            if (cq.Count > 0)
            {
                while (cq.TryDequeue(out string log))
                {
                    string timestamp = log.Substring(0, 23);
                    string message = log.Substring(25);
                    var logEntry = new { timestamp = timestamp, message = message };
                    string jsonLog = JsonSerializer.Serialize(logEntry);
                    using (StreamWriter file = new StreamWriter(filePath, true))
                    {   FileInfo fileInfo = new FileInfo(filePath);
                        if(fileInfo.Length == 0)
                        {
                            file.WriteLine("[");
                        }
                        if (fileInfo.Length > 2)
                        {
                            file.WriteLine(",");
                        }
                        file.WriteLine(jsonLog);
                    }
                }
            }
        }

        public void koniecZapisow()
        {
            using (StreamWriter file = new StreamWriter(filePath, true))
            {   while(cq.Count > 0)
                {
                    zapiszLogi();
                }
                file.WriteLine("]");
            }
        }
       
    }
}
