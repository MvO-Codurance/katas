using AutoFixture.Xunit2;
using FluentAssertions;
using GildedRose.Console;
using GildedRose.Console.UpdateStrategies;
using Xunit;

namespace GildedRose.Tests
{
    public class UpdateStrategyShould
    {
        [Theory]
        [InlineAutoData(1, 10, 9)]
        [InlineAutoData(1, 1, 0)]
        [InlineAutoData(1, 0, 0)]
        [InlineAutoData(1, 10, 9)]
        [InlineAutoData(0, 10, 8)]
        [InlineAutoData(-1, 10, 8)]
        [InlineAutoData(-1, 2, 0)]
        [InlineAutoData(-1, 0, 0)]
        public void Decrement_Quality_For_Standard_Items(
            int initialSellIn,
            int initialQuality,
            int expectedQuality,
            Item item,
            StandardItemUpdateStrategy sut)
        {
            // arrange
            item.SellIn = initialSellIn;
            item.Quality = initialQuality;
            
            // act
            sut.Update(item);

            // assert
            item.Quality.Should().Be(expectedQuality);
        }
        
        [Theory]
        [InlineAutoData(10, 9)]
        [InlineAutoData(1, 0)]
        [InlineAutoData(0, -1)]
        public void Decrement_SellIn_For_Standard_Items(
            int initialSellIn,
            int expectedSellIn,
            Item item,
            StandardItemUpdateStrategy sut)
        {
            // arrange
            item.SellIn = initialSellIn;
            
            // act
            sut.Update(item);

            // assert
            item.SellIn.Should().Be(expectedSellIn);
        }
        
        [Theory]
        [InlineAutoData(1, 5, 6)]
        [InlineAutoData(1, 0, 1)]
        [InlineAutoData(1, 50, 50)]
        [InlineAutoData(1, 10, 11)]
        [InlineAutoData(0, 10, 12)]
        [InlineAutoData(-1, 10, 12)]
        [InlineAutoData(-1, 48, 50)]
        [InlineAutoData(-1, 50, 50)]
        public void Increment_Quality_For_Aged_Brie(
            int initialSellIn,
            int initialQuality,
            int expectedQuality,
            Item item,
            AgedBrieUpdateStrategy sut)
        {
            // arrange
            item.SellIn = initialSellIn;
            item.Quality = initialQuality;
            
            // act
            sut.Update(item);

            // assert
            item.Quality.Should().Be(expectedQuality);
        }
        
        [Theory]
        [InlineAutoData(10, 9)]
        [InlineAutoData(1, 0)]
        [InlineAutoData(0, -1)]
        public void Decrement_SellIn_For_Aged_Brie(
            int initialSellIn,
            int expectedSellIn,
            Item item,
            AgedBrieUpdateStrategy sut)
        {
            // arrange
            item.SellIn = initialSellIn;
            
            // act
            sut.Update(item);

            // assert
            item.SellIn.Should().Be(expectedSellIn);
        }
        
        [Theory]
        [InlineAutoData(5)]
        [InlineAutoData(10)]
        [InlineAutoData(80)]
        public void Leave_Quality_Unchanged_For_Legendary_Items(
            int initialQuality,
            Item item,
            LegendaryItemUpdateStrategy sut)
        {
            // arrange
            item.Quality = initialQuality;
            
            // act
            sut.Update(item);

            // assert
            item.Quality.Should().Be(initialQuality);
        }
        
        [Theory]
        [InlineAutoData(5)]
        [InlineAutoData(10)]
        [InlineAutoData(80)]
        public void Leave_SellIn_Unchanged_For_Legendary_Items(
            int initialSellIn,
            Item item,
            LegendaryItemUpdateStrategy sut)
        {
            // arrange
            item.SellIn = initialSellIn;
            
            // act
            sut.Update(item);

            // assert
            item.SellIn.Should().Be(initialSellIn);
        }
    }
}