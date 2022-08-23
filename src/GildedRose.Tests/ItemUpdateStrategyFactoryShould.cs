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
        public void Return_The_Standard_Strategy_For_Standard_Items(string name, Type strategyType)
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