namespace GildedRose.Console.UpdateStrategies
{
    public class BackstagePassUpdateStrategy : IItemUpdateStrategy
    {
        public void Update(Item item)
        {
            const int maxQuality = 50;
            
            int qualityIncrement = 1;

            if (item.SellIn <= 5)
            {
                qualityIncrement = 3;
            }
            else if (item.SellIn <= 10)
            {
                qualityIncrement = 2;
            }
            
            item.Quality = item.Quality <= maxQuality - qualityIncrement ? item.Quality + qualityIncrement : maxQuality;
            
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            
            item.SellIn--;
        }
    }
}