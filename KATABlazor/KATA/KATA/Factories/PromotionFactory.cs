namespace KATA
{
    public class PromotionFactory
    {
        public IPromotion GetPromotion(string SKU) {
            return SKU switch
            {
                "B" => new PromotionB(),
                "D" => new PromotionD(),
                _ => null,
            };
        }
    }
}
