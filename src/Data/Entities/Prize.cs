using System;
using System.Collections.Generic;

namespace Handsoft.Prizes.App.Data.Entities
{
    public partial class Prize
    {
        public int Id { get; set; }
        public int? DrawId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public int? Count { get; set; }
        public int? Given { get; set; }
        public string Image { get; set; }
        public string MessageOut { get; set; }
    }
}
