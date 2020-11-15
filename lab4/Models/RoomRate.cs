using System;
using System.Collections.Generic;

namespace lab4.Models
{
    public partial class RoomRate
    {
        public int Id { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? Date { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
