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
                
                case "+5 Dexterity Vest":
                case "Elixir of the Mongoose":
                    return new StandardItemUpdateStrategy();
                
                default:
                    return null;
            }
        }
    }
}