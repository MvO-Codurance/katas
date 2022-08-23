using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GildedRose.Console;
using VerifyXunit;
using Xunit;

namespace GildedRose.Tests
{
    [UsesVerify]
    public class TestAssemblyTests
    {
        private const int FixedSeed = 100;
        private const int NumberOfRandomItems = 2000;
        private const int Minimum = -50;
        private const int Maximum = 101;
        
        private readonly string[] _itemNames = {"+5 Dexterity Vest",
            "Aged Brie",
            "Elixir of the Mongoose",
            "Sulfuras, Hand of Ragnaros",
            "Backstage passes to a TAFKAL80ETC concert",
            "Conjured Mana Cake"};

        private readonly Random _random = new Random(FixedSeed);
        private readonly Console.GildedRose _gildedRose = new Console.GildedRose();

        [Fact]
        public Task Should_Generate_Update_Quality_Output()
        {
            List<Item> items = GenerateRandomItems(NumberOfRandomItems);

            _gildedRose.UpdateQuality(items);

            return Verifier.Verify(GetStringRepresentationFor(items));
        }

        private List<Item> GenerateRandomItems(int totalNumberOfRandomItems) {
            var items = new List<Item>();
            for (int cnt = 0; cnt < totalNumberOfRandomItems; cnt++) {
                items.Add(new Item { Name = ItemName(), SellIn = SellIn(), Quality = Quality() });
            }
            return items;
        }

        private string ItemName() {
            return _itemNames[0 + _random.Next(_itemNames.Length)];
        }

        private int SellIn() {
            return RandomNumberBetween(Minimum, Maximum);
        }

        private int Quality() {
            return RandomNumberBetween(Minimum, Maximum);
        }

        private int RandomNumberBetween(int minimum, int maximum) {
            return minimum + _random.Next(maximum);
        }

        private string GetStringRepresentationFor(List<Item> items) {
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.AppendLine($"Item [name={item.Name}, sellIn={item.SellIn}, quality={item.Quality}]");
            }
            return builder.ToString();
        }
    }
}