using System;
using System.Collections.Generic;

namespace Handsoft.Prizes.App.Data.Entities
{
    public partial class Help
    {
        public int Id { get; set; }
        public string InNumber { get; set; }
        public string Message { get; set; }
        public string OutNumber { get; set; }
    }
}
