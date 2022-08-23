namespace GildedRose.Console.UpdateStrategies
{
    public class AgedBrieUpdateStrategy : IItemUpdateStrategy
    {
        public void Update(Item item)
        {
            const int maxQuality = 50;
            
            item.SellIn--;

            int qualityIncrement = item.SellIn < 0 ? 2 : 1;
            item.Quality = item.Quality <= maxQuality - qualityIncrement ? item.Quality + qualityIncrement : maxQuality;
        }
    }
}