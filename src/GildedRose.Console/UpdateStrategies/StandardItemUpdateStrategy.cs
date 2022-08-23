namespace GildedRose.Console.UpdateStrategies
{
    public class StandardItemUpdateStrategy : IItemUpdateStrategy
    {
        public void Update(Item item)
        {
            item.SellIn--;

            int qualityDecrement = item.SellIn < 0 ? 2 : 1;
            item.Quality = item.Quality >= qualityDecrement ? item.Quality - qualityDecrement : 0;
        }
    }
}