namespace GildedRose.Console.UpdateStrategies
{
    public class ConjuredItemUpdateStrategy : IItemUpdateStrategy
    {
        public void Update(Item item)
        {
            int qualityDecrement = item.SellIn <= 0 ? 4 : 2;
            item.Quality = item.Quality >= qualityDecrement ? item.Quality - qualityDecrement : 0;
            
            item.SellIn--;
        }
    }
}