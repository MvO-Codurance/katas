namespace GildedRose.Console.UpdateStrategies
{
    public class BackstagePassUpdateStrategy : IItemUpdateStrategy
    {
        public void Update(Item item)
        {
            if (item.SellIn <= 5)
            {
                item.IncrementQualityBy(3);
            }
            else if (item.SellIn <= 10)
            {
                item.IncrementQualityBy(2);
            }
            else
            {
                item.IncrementQuality();
            }
            
            if (item.HasExpired())
            {
                item.Quality = 0;
            }
            
            item.DecrementSellIn();
        }
    }
}