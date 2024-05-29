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
            string sciezkafolder = Path.GetDirectoryName(cala);
            if (!Directory.Exists(sciezkafolder))
            {
                Directory.CreateDirectory(sciezkafolder);
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
