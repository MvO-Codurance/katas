namespace GildedRose.Console.UpdateStrategies
{
    public class ItemUpdateStrategyFactory
    {
        public IItemUpdateStrategy Get(string name)
        {
            switch (name)
            {
                case "Aged Brie":
                    return new AgedBrieUpdateStrategy();
                
                case "Sulfuras, Hand of Ragnaros":
                    return new LegendaryItemUpdateStrategy();
                
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassUpdateStrategy();
                
                case "Conjured Mana Cake":
                    return new ConjuredItemUpdateStrategy();
                
                default:
                    return new StandardItemUpdateStrategy();
            }
        }
    }
}