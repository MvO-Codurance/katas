using System.Collections.Generic;
using System.Linq;

namespace ParallelAndNarrowChange.Field
{
    public class ShoppingCart{
        private List<int> prices = new List<int>();

        public decimal CalculateTotalPrice()
        {
            return prices.Sum();
        }
        
        public bool HasDiscount()
        {
            return prices.Any(p => p > 100);
        }
        
        public void Add(params int[] thePrices){
            prices.AddRange(thePrices);
        }
        
        public int NumberOfProducts(){
            return prices.Count;
        }
    }
}
