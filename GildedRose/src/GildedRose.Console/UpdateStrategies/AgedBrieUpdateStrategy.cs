namespace GildedRose.Console.UpdateStrategies
{
    public class AgedBrieUpdateStrategy : IItemUpdateStrategy
    {
        public void Update(Item item)
        {
            if (item.HasExpired())
            {
                item.IncrementQualityBy(2);
            }
            else
            {
                item.IncrementQuality();
            }

            item.DecrementSellIn();
        }
    }
}