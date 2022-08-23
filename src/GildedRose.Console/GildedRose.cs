using System;
using System.Collections.Generic;
using GildedRose.Console.UpdateStrategies;

namespace GildedRose.Console
{
    public class GildedRose
    {
        private readonly ItemUpdateStrategyFactory _strategyFactory;

        public GildedRose(ItemUpdateStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory ?? throw new ArgumentNullException(nameof(strategyFactory));
        }
        
        public void UpdateQuality(IList<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                var updateStrategy = _strategyFactory.Get(items[i].Name);
                if (updateStrategy != null)
                {
                    updateStrategy.Update(items[i]);
                    continue;
                }
                
                if (items[i].Name != "Aged Brie" && items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (items[i].Quality > 0)
                    {
                        if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            items[i].Quality = items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (items[i].Quality < 50)
                    {
                        items[i].Quality = items[i].Quality + 1;

                        if (items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (items[i].SellIn < 11)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }

                            if (items[i].SellIn < 6)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    items[i].SellIn = items[i].SellIn - 1;
                }

                if (items[i].SellIn < 0)
                {
                    if (items[i].Name != "Aged Brie")
                    {
                        if (items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (items[i].Quality > 0)
                            {
                                if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    items[i].Quality = items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            items[i].Quality = items[i].Quality - items[i].Quality;
                        }
                    }
                    else
                    {
                        if (items[i].Quality < 50)
                        {
                            items[i].Quality = items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}