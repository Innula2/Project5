using System;
using System.Collections.Generic;

namespace Project5
{
    public partial class Operation
    {
        public int Id { get; set; }
        public int? Dealid { get; set; }
        public int? Subaccountid { get; set; }
        public int Number { get; set; }
        public DateOnly? Data { get; set; }
        public string Type { get; set; } = null!;
        public string Sum { get; set; } = null!;
        public decimal? Saldoinput { get; set; }
        public decimal? Saldooutput { get; set; }

        public virtual Deal? Deal { get; set; }
        public virtual Subaccount? Subaccount { get; set; }
    }
}
