using System;
using System.Collections.Generic;

namespace Project5
{
    public partial class Subaccount
    {
        public Subaccount()
        {
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public int? Accountplanid { get; set; }
        public string Name { get; set; } = null!;
        public double Number { get; set; }

        public virtual Accountplan? Accountplan { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
