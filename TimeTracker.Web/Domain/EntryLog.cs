using System;

namespace TimeTracker.Web.Domain
{
    public class EntryLog
    {
        public int EntryLogId { get; set; }

        public decimal Duration { get; set; }

        public string Description { get; set; }

        public DateTime EntryDate { get; set; }

        public string Project { get; set; }
    }
}