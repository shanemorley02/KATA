using static KATA.Pages.Items;

namespace KATA
{
    public class PromotionD : IPromotion
    {
        public decimal Calculate(Item item)
        {
            int tempQty = item.Qty;
            decimal itemTotal = 0.0m;

            do
            {
                if (tempQty < 2)
                {
                    itemTotal += tempQty * item.UnitPrice;
                    tempQty -= tempQty;
                }
                else
                {
                    //25% off for every 2 purchased together.
                    tempQty -= 2;
                    decimal tempPrice = item.UnitPrice * 2;
                    decimal difference = (tempPrice / 100) * 25;
                    itemTotal += (tempPrice - difference);
                }

            } while (tempQty > 0);

            return itemTotal;
        }
    }
}
