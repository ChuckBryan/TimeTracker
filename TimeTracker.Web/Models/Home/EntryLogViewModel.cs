using System;

namespace TimeTracker.Web.Models.Home
{
    public class EntryLogViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Duration { get; set; }

        public DateTime EntryDate { get; set; }

        public string Project { get; set; }
    }
}