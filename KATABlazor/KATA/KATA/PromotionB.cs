using static KATA.Pages.Items;

namespace KATA
{
    public class PromotionB : IPromotion
    {
        public decimal Calculate(Item item)
        {
            int tempQty = item.Qty;
            decimal itemTotal = 0.0m;

            do
            {
                if (tempQty < 3)
                {
                    itemTotal += tempQty * item.UnitPrice;
                    tempQty -= tempQty;
                }
                else
                {
                    //3 for 40
                    tempQty -= 3;
                    itemTotal += (3 * item.UnitPrice) - 5;
                }

            } while (tempQty > 0);

            return itemTotal;
        }
    }
}
