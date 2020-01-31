using System;
using System.Collections.Generic;

namespace Handsoft.Prizes.App.Data.Entities
{
    public partial class Draw
    {
        public int Id { get; set; }
        public bool? OutputDisabled { get; set; }
        public string OutNumber { get; set; }
        public string InputNumber { get; set; }
        public string InnactiveOutputNumber { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public int? CodeLen { get; set; }
        public int? ClientId { get; set; }
        public bool? Active { get; set; }
        public string InnactiveMessage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Keyword { get; set; }
        public string Entries { get; set; }
        public string CountText { get; set; }
        public string QueryOutNumber { get; set; }
        public string QueryMessage { get; set; }
        public int? Mode { get; set; }
        public bool? GenerateCode { get; set; }
        public int? FakeId { get; set; }
        public bool? Sendsms { get; set; }
        public bool? Deleted { get; set; }

        public Trackerservice Trackerservice { get; set; }
    }
}
