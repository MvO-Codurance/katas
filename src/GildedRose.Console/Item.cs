namespace GildedRose.Console
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public override string ToString()
        {
            return $"Item [name={Name}, sellIn={SellIn}, quality={Quality}]";
        }
    }
}