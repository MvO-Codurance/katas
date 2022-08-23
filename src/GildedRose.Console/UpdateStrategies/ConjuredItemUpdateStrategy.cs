namespace GildedRose.Console.UpdateStrategies
{
    public class ConjuredItemUpdateStrategy : IItemUpdateStrategy
    {
        public void Update(Item item)
        {
            if (item.HasExpired())
            {
                item.DecrementQualityBy(4);
            }
            else
            {
                item.DecrementQualityBy(2);
            }

            item.DecrementSellIn();
        }
    }
}