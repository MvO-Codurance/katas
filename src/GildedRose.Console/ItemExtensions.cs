namespace GildedRose.Console
{
    public static class ItemExtensions
    {
        public static bool HasExpired(this Item item)
        {
            return item.SellIn <= 0;
        }
        
        public static void DecrementSellIn(this Item item)
        {
            item.SellIn--;
        }
        
        public static void DecrementQuality(this Item item)
        {
            item.DecrementQualityBy(1);
        }
        
        public static void DecrementQualityBy(this Item item, int decrement)
        {
            const int minQuality = 0;
            
            if (item.Quality >= decrement)
            {
                item.Quality -= decrement;
            }
            else
            {
                item.Quality = minQuality;
            }
        }
        
        public static void IncrementQuality(this Item item)
        {
            item.IncrementQualityBy(1);
        }
        
        public static void IncrementQualityBy(this Item item, int increment)
        {
            const int maxQuality = 50;
            
            if (item.Quality <= maxQuality - increment)
            {
                item.Quality += increment;
            }
            else
            {
                item.Quality = maxQuality;
            }
        }
    }
}