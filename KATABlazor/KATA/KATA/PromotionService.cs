using static KATA.Pages.Items;

namespace KATA
{
    public class PromotionService: IPromotionService
    {
        public decimal CalculatePromotions(Item item)
        {
            int tempQty = item.Qty;
            decimal itemTotal = 0.0m;

            switch (item.ItemSKU)
            {
                case "B":
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

                case "D":
                    do
                    {
                        if (tempQty < 2)
                        {
                            itemTotal += tempQty * item.UnitPrice;
                            tempQty -= tempQty;
                        }
                        else {
                            //25% off for every 2 purchased together.
                            tempQty -= 2;
                            itemTotal += 25 / 100 * item.UnitPrice * 2;
                        }

                    } while (tempQty > 0);

                    return itemTotal;

                default:
                    itemTotal += tempQty * item.UnitPrice;
                    return itemTotal;
            }
        }
    }
}
