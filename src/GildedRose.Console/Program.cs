using System.Collections.Generic;
using System.Diagnostics;

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
            Debug.Assert(program.Items != null);
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
            Debug.Assert(Items!=null && Items.Count > 0);
            foreach (var item in Items)
            {
                Debug.Assert(item != null);
                UpdateQuality(item);
            }
        }

        public void UpdateQuality(Item item)
        {
            Debug.Assert(item!=null);
            item.Update();
        }
    }
}
