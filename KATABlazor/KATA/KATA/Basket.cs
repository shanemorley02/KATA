using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KATA.Pages.Items;

namespace KATA
{
    public class Basket
    {
        public Item Items { get; set; }
        public decimal Total { get; set; }
    }
}
