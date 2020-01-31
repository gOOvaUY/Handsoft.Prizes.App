using System;
using System.Collections.Generic;

namespace Handsoft.Prizes.App.Data.Entities
{
    public partial class Winner
    {
        public int Id { get; set; }
        public DateTime? Wtime { get; set; }
        public bool? Main { get; set; }
        public int? PrizeId { get; set; }
        public int? UserId { get; set; }
    }
}
