using System.Collections.Generic;
using static KATA.Pages.Items;

namespace KATA
{
    //this service could be anywhere, in its own project or even on an api.
    //we pass in a list of items added to the basket and will calculate the totals.
    public class PricingService: IPricingService
    {
        private readonly IPromotionService _promotionService;
        public PricingService(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }
        public decimal CalculateTotalPrice(IEnumerable<Item> items) {
            decimal total = 0.0m;

            foreach (var item in items)
            {
                if (item.Promotion)
                {
                    total += _promotionService.CalculatePromotions(item);
                }
                else {
                    total += item.Qty * item.UnitPrice;
                }
            }

            return total;
        }
    }
}
