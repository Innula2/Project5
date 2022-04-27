using System;
using System.Collections.Generic;

namespace Project5
{
    public partial class Accountplan
    {
        public Accountplan()
        {
            Subaccounts = new HashSet<Subaccount>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int Number { get; set; }

        public virtual ICollection<Subaccount> Subaccounts { get; set; }
    }
}
