using System.Collections.Generic;
using System.Linq;

namespace ParallelAndNarrowChange.Field
{
    public class ShoppingCart{
        private decimal price;
        private List<int> prices = new List<int>();

        public decimal CalculateTotalPrice(){
            return price;
        }
        
        public decimal CalculateTotalPriceMultiple()
        {
            return prices.Sum();
        }

        public bool HasDiscount(){
            return price > 100;
        }
        
        public bool HasDiscountMultiple()
        {
            return prices.Any(p => p > 100);
        }

        public void Add(int aPrice){
            price = aPrice;
        }
        
        public void AddMultiple(params int[] prices){
            this.prices.AddRange(prices);
        }

        public int NumberOfProducts(){
            return 1;
        }
        
        public int NumberOfProductsMultiple(){
            return this.prices.Count;
        }
    }
}
