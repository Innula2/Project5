using System;
using System.Collections.Generic;

namespace Project5
{
    public partial class Deal
    {
        public Deal()
        {
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public int? Agreement { get; set; }
        public string? Tiker { get; set; }
        public int? OrderDeal { get; set; }
        public int? NumberDeal { get; set; }
        public DateTime? Date { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Totalcost { get; set; }
        public int? Trader { get; set; }
        public string? Commission { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
