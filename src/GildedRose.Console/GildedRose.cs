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
            foreach (var item in items)
            {
                var updateStrategy = _strategyFactory.Get(item.Name);
                updateStrategy.Update(item);
            }
        }
    }
}