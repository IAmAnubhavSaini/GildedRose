using System.Collections.Generic;
using System.Security;
using System.Security.AccessControl;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              ItemFactory.GenerateItem(ItemType.Normal,"+5 Dexterity Vest",10,20),
                                              ItemFactory.GenerateItem(ItemType.AgedBrie,  "Aged Brie",2,0),
                                              ItemFactory.GenerateItem(ItemType.Normal, "Elixir of the Mongoose",5,7),
                                              ItemFactory.GenerateItem(ItemType.Legendary, "Sulfuras, Hand of Ragnaros", 0,80),
                                              ItemFactory.GenerateItem(ItemType.BackstagePass, "Backstage passes to a TAFKAL80ETC concert",15,20),
                                              ItemFactory.GenerateItem(ItemType.Conjured, "Conjured Mana Cake",3,6)
                                              
                                          }

                          };
            for(var i = 0; i < 5; ++i)
                app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                System.Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                if (item is Updateable)
                {
                    System.Console.WriteLine("updating");
                    ((Updateable)item).Update();
                }
                System.Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                System.Console.WriteLine("-------------------------------");

            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

    public enum ItemType
    {
        Normal,
        Legendary,
        AgedBrie,
        BackstagePass,
        Conjured
    }

    public static class ItemFactory
    {
        public static Item GenerateItem(ItemType type, string name, int sellIn, int quality)
        {
            switch (type)
            {
                case ItemType.Normal:
                    return new NormalItem() { Name = name, SellIn = sellIn, Quality = quality };
                //break;
                case ItemType.Legendary:
                    return new LegendaryItem() { Name = name, SellIn = sellIn, Quality = quality };
                //break;
                case ItemType.BackstagePass:
                    return new BackstagePassItem() { Name = name, SellIn = sellIn, Quality = quality };
                //break;
                case ItemType.AgedBrie:
                    return new AgedBrieItem() { Name = name, SellIn = sellIn, Quality = quality };
                //break;
                case ItemType.Conjured:
                    return new ConjuredItem() { Name = name, SellIn = sellIn, Quality = quality };
                //break;
                default:
                    return null;
                //break;
            }
        }
    }
    public interface Updateable
    {
        void Update();
    }

    public interface QualityMeasureable
    {
        int MinQuality { get; }
        int MaxQuality { get; }
    }
    public class LegendaryItem : Item, QualityMeasureable
    {

        public int MinQuality
        {
            get { return 80; }
        }

        public int MaxQuality
        {
            get { return 80; }
        }
    }

    public class ConjuredItem : Item, QualityMeasureable, Updateable
    {

        public int MinQuality
        {
            get { return 0; }
        }

        public int MaxQuality
        {
            get { return 50; }
        }

        public void Update()
        {
            if (SellIn <= 0)
            {
                Quality -= 4;
                SellIn = 0;
            }
            else
            {
                Quality -= 2;
                SellIn -= 1;
            }
            if (Quality < MinQuality) Quality = MinQuality;
        }
    }

    public class BackstagePassItem : Item, QualityMeasureable, Updateable
    {

        public void Update()
        {
            if (SellIn <= 0)
            {
                Quality = 0;
                SellIn = 0;
            }
            else if (SellIn <= 5)
            {
                Quality += 3;
                SellIn -= 1;
            }
            else if (SellIn <= 10)
            {
                Quality += 2;
                SellIn -= 1;
            }
            else
            {
                Quality += 1;
                SellIn -= 1;
            }
            if (Quality > MaxQuality) Quality = MaxQuality;
        }

        public int MinQuality
        {
            get { return 0; }
        }

        public int MaxQuality
        {
            get { return 50; }
        }
    }

    public class AgedBrieItem : Item, QualityMeasureable, Updateable
    {

        public int MinQuality
        {
            get { return 0; }
        }

        public int MaxQuality
        {
            get { return 50; }
        }

        public void Update()
        {
            Quality += 1;
            if (SellIn <= 0) SellIn = 0;
            if (Quality > MaxQuality) Quality = MaxQuality;
            SellIn -= 1;
        }
    }

    public class NormalItem : Item, QualityMeasureable, Updateable
    {

        public int MinQuality
        {
            get { return 0; }
        }

        public int MaxQuality
        {
            get { return 50; }
        }

        public void Update()
        {
            if (SellIn <= 0)
            {
                SellIn = 0;
                Quality -= 2;
            }
            else
            {
                Quality -= 1;
                SellIn -= 1;
            }

            if (Quality > MaxQuality) Quality = MaxQuality;
            if (Quality < MinQuality) Quality = MinQuality;
        }
    }
}
