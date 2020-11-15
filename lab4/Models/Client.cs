using System;
using System.Collections.Generic;

namespace lab4.Models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Surname { get; set; }
        public string PassportData { get; set; }
        public string NameOfRoom { get; set; }
        public string List { get; set; }
        public decimal? TotalCost { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
