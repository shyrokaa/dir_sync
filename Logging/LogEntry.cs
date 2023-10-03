using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dir_sync.Logging
{
    // object class that represents a log that was made when a file was transfered
    internal class LogEntry
    {
        public DateTime TimeCreated { get; set; }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public long FileSizeBytes { get; set; }
        public string Status { get; set; }
    }
}
