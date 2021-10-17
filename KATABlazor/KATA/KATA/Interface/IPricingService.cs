using System.Collections.Generic;
using static KATA.Pages.Items;

namespace KATA
{
    public interface IPricingService
    {
        public decimal CalculateTotalPrice(IEnumerable<Item> items);
    }
}
