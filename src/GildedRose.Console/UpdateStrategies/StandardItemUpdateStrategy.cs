namespace GildedRose.Console.UpdateStrategies
{
    public class StandardItemUpdateStrategy : IItemUpdateStrategy
    {
        public void Update(Item item)
        {
            if (item.HasExpired())
            {
                item.DecrementQualityBy(2);
            }
            else
            {
                item.DecrementQuality();
            }
            
            item.DecrementSellIn();
        }
    }
}