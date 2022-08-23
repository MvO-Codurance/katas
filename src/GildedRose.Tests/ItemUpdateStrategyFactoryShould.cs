using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using GildedRose.Console.UpdateStrategies;
using Xunit;

namespace GildedRose.Tests
{
    public class ItemUpdateStrategyFactoryShould
    {
        [Theory]
        [InlineAutoData("+5 Dexterity Vest", typeof(StandardItemUpdateStrategy))]
        [InlineAutoData("Elixir of the Mongoose", typeof(StandardItemUpdateStrategy))]
        [InlineAutoData("Aged Brie", typeof(AgedBrieUpdateStrategy))]
        [InlineAutoData("Sulfuras, Hand of Ragnaros", typeof(LegendaryItemUpdateStrategy))]
        [InlineAutoData("Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassUpdateStrategy))]
        public void Return_The_Correct_Strategy(string name, Type strategyType)
        {
            // arrange
            var sut = new ItemUpdateStrategyFactory();

            // act
            var actual = sut.Get(name);
            
            // assert
            actual.Should().BeOfType(strategyType);
        }
    }
}