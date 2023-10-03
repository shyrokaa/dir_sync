using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace dir_sync.Logging
{
    internal class Logger
    {
        private string filePath;

        /// <summary>
        /// Logger object construction that requires a path.
        /// </summary>
        /// <param name="path">The path to the JSON log file.</param>
        public Logger(string path)
        {
            this.filePath = path;
        }

        /// <summary>
        /// Reads the current logs from the file.
        /// </summary>
        /// <returns>A list of log entries.</returns>
        /// <summary>
        /// Reads the current logs from the file. If the file doesn't exist, it creates it.
        /// </summary>
        /// <returns>A list of log entries.</returns>
        public List<LogEntry> ReadLogs()
        {
            List<LogEntry> logs = new List<LogEntry>();

            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    logs = JsonConvert.DeserializeObject<List<LogEntry>>(json);
                }
                else
                {
                    // If the file doesn't exist, create it and write an empty list of logs.
                    File.WriteAllText(filePath, "[]");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., file access errors) here.
                Console.WriteLine($"Error reading logs: {ex.Message}");
            }

            return logs;
        }


        /// <summary>
        /// Adds a new log to the file.
        /// </summary>
        /// <param name="newLog">The log entry to be added.</param>
        public void UpdateLogs(LogEntry newLog)
        {
            List<LogEntry> logs = ReadLogs();
            logs.Add(newLog);

            string json = JsonConvert.SerializeObject(logs, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Prints all the logs into a specific string for the UI.
        /// </summary>
        /// <returns>A formatted string containing log entries.</returns>
        public string PrintLogs()
        {
            List<LogEntry> logs = ReadLogs();
            StringBuilder logString = new StringBuilder();

            if (logs != null)
            {
                foreach (LogEntry log in logs)
                {
                    logString.AppendLine();
                    logString.AppendLine("////////////////////////////////////////");
                    logString.AppendLine($"Time Created: {log.TimeCreated}");
                    logString.AppendLine($"Source Path: {log.SourcePath}");
                    logString.AppendLine($"Destination Path: {log.DestinationPath}");
                    logString.AppendLine($"File Size (Bytes): {log.FileSizeBytes}");
                    logString.AppendLine($"Status: {log.Status}");
                    logString.AppendLine("////////////////////////////////////////");
                    logString.AppendLine();
                }
            }


            return logString.ToString();

        }


        /// <summary>
        /// Deletes all the logs from the file.
        /// </summary>
        public void WipeLogs()
        {
            File.Delete(filePath);
        }

    }
}
