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
        private string filePath;

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


        public void zapiszLogi(string data_czas, string wiadomosc)
        {
            string dane = "";
            if (File.Exists(this.filePath))
            {
                dane = File.ReadAllText(this.filePath);
                if (dane.Length > 0)
                {
                    dane = dane.Remove(dane.Length - 3);
                    File.WriteAllText(this.filePath, dane);
                }
            }
            var logEntry = new { timestamp = data_czas, message = wiadomosc };
            string jsonLog = JsonSerializer.Serialize(logEntry);
            using (StreamWriter file = new StreamWriter(filePath, true))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Length == 0)
                {
                    file.WriteLine("[");
                }
                if (fileInfo.Length > 2)
                {
                    file.WriteLine(",");
                }
                file.WriteLine(jsonLog);
                file.WriteLine("]");
            }
        }
    }
}