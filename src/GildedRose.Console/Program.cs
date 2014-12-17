using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items { get; private set; }

        public Program()
        {
            Items = new List<Item>
            {
                new StandardItem { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new AgedBrieItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new StandardItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new LegendaryItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new BackstagePassItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new ConjuredItem() {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }
        static void Main()
        {
            var program = new Program();
            program.PrintItems();
            program.UpdateQuality();
            program.PrintItems();
        }

        private void PrintItems()
        {
            var i = 0;
            System.Console.WriteLine();
            foreach (var item in Items)
            {
                System.Console.WriteLine(++i + ". " + item.Name + " - Quality: " + item.Quality + ", Sell in: " + item.SellIn);
            }
            System.Console.WriteLine();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateQuality(item);
            }
        }

        public Item UpdateQuality(Item item)
        {
            item.Update();
            return item;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public virtual void Update()
        {
            UpdateSellIn();
            UpdateQuality();
        }

        protected virtual void UpdateSellIn()
        {
            if (SellIn > 0)
                SellIn--;
        }

        protected virtual void UpdateQuality()
        {
            if (Quality <= 0) return;
            if (SellIn == 0)
                Quality -= 2;
            else
                Quality--;
        }
    }

    public class StandardItem : Item { }

    public class AgedBrieItem : Item
    {
        protected override void UpdateQuality()
        {
            if (Quality < 50)
                Quality++;
        }
    }

    public class LegendaryItem : Item
    {
        public override void Update()
        {
            // do nothing
        }
    }

    public class BackstagePassItem : Item
    {
        protected override void UpdateQuality()
        {
            if (SellIn > 10) Quality++;
            else if (SellIn > 5) Quality += 2;
            else if (SellIn > 0) Quality += 3;
            else if (SellIn == 0) Quality = 0;
        }
    }

    public class ConjuredItem : Item
    {
        protected override void UpdateQuality()
        {
            if (SellIn > 0)
                Quality -= 2;
            else
                Quality -= 4;
        }
    }
}
