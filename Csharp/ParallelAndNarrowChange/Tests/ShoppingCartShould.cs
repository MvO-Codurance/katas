using FluentAssertions;
using NUnit.Framework;
using ParallelAndNarrowChange.Field;

namespace ParallelAndNarrowChange{
    [TestFixture]
    public class ShoppingCartShould{
        private ShoppingCart cart;

        [SetUp]
        public void SetUp(){
            cart = new ShoppingCart();
        }

        [Test]
        public void calculate_the_final_price(){
            cart.AddMultiple(10);

            cart.CalculateTotalPriceMultiple().Should().Be(10);
        }
        
        [Test]
        public void calculate_the_final_price_multiple(){
            cart.AddMultiple(10, 20, 30);

            cart.CalculateTotalPriceMultiple().Should().Be(60);
        }

        [Test]
        public void knows_the_number_of_items(){
            cart.AddMultiple(10);

            cart.NumberOfProductsMultiple().Should().Be(1);
        }
        
        [Test]
        public void knows_the_number_of_items_multiple(){
            cart.AddMultiple(10, 20, 30);

            cart.NumberOfProductsMultiple().Should().Be(3);
        }

        [Test]
        public void may_offer_discounts_when_there_at_least_one_expensive_product(){
            cart.AddMultiple(120);

            cart.HasDiscountMultiple().Should().BeTrue();
        }
        
        [Test]
        public void may_offer_discounts_when_there_at_least_one_expensive_product_multiple(){
            cart.AddMultiple(10, 20, 120);

            cart.HasDiscountMultiple().Should().BeTrue();
        }

        [Test]
        public void does_not_offer_discount_for_cheap_products(){
            cart.AddMultiple(10);

            cart.HasDiscountMultiple().Should().BeFalse();
        }
        
        [Test]
        public void does_not_offer_discount_for_cheap_products_multiple(){
            cart.AddMultiple(10, 20, 30);

            cart.HasDiscountMultiple().Should().BeFalse();
        }
    }
}
