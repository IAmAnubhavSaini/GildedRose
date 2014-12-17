using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class WhenIUpdateItems
    {
        [TestFixture]
        public class WithAStandardItem
        {

            [Test]
            public void it_should_decrement_sell_in()
            {
                var item = new StandardItem{Name = "standard item", SellIn = 1, Quality = 1 }.UpdateQuality();
                Assert.That(item.SellIn, Is.EqualTo(0));
            }

            [Test]
            public void it_should_decrement_quality()
            {
                var item = new StandardItem { Name = "standard item", SellIn = 1, Quality = 1 }.UpdateQuality();
                Assert.That(item.Quality, Is.EqualTo(0));
            }

            [Test]
            public void when_the_sell_in_has_passed_it_should_decrement_quality_twice_as_fast()
            {
                var item = new StandardItem { Name = "standard item", SellIn = 0, Quality = 2 }.UpdateQuality();
                Assert.That(item.Quality, Is.EqualTo(0));
            }

            [Test]
            public void quality_should_never_be_negative()
            {
                var item = new StandardItem { Name = "standard item", SellIn = 1, Quality = 0 }.UpdateQuality();
                Assert.That(item.Quality, Is.EqualTo(0));
            }
        }

        [TestFixture]
        public class WithALegendaryItem
        {
       
            [Test]
            public void it_should_not_decrease_in_quality()
            {
                var item = new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", Quality = 1, SellIn = 1 }.UpdateQuality();
                Assert.That(item.Quality, Is.EqualTo(1));
            }

            [Test]
            public void it_should_not_decrease_sell_in()
            {
                var item = new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", Quality = 1, SellIn = 1 }.UpdateQuality();
                Assert.That(item.SellIn, Is.EqualTo(1));
            }
        }

        [TestFixture]
        public class WithAgedBrieItem
        {

            [Test]
            public void it_should_increase_in_quality()
            {
                var item = new AgedBrieItem { Name = "Aged Brie", Quality = 1, SellIn = 1 }.UpdateQuality();
                Assert.That(item.Quality, Is.EqualTo(2));
            }

            [Test]
            public void quality_should_never_increase_beyond_fifty()
            {
                var item = new AgedBrieItem { Name = "Aged Brie", Quality = 50, SellIn = 1 }.UpdateQuality();
                Assert.That(item.Quality, Is.EqualTo(50));
            }

            [Test]
            public void sell_in_should_still_decrement_normally()
            {
                var item = new AgedBrieItem { Name = "Aged Brie", Quality = 1, SellIn = 1 }.UpdateQuality();
                Assert.That(item.SellIn, Is.EqualTo(0));
            }
        }

        [TestFixture]
        public class WithABackstagePassItem
        {

            [Test]
            public void it_should_increase_in_quality()
            {
                var item = new BackstagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 11 }.UpdateQuality();
                Assert.That(item.Quality, Is.EqualTo(2));
            }

            [TestCase(10)]
            [TestCase(9)]
            [TestCase(8)]
            [TestCase(7)]
            [TestCase(6)]
            public void it_should_increase_quality_by_two_when_there_are_ten_or_less_days_left(int daysLeft)
            {
                var item = new BackstagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = daysLeft }.UpdateQuality();
                Assert.That(item.Quality, Is.EqualTo(3));
            }

            [TestCase(5)]
            [TestCase(4)]
            [TestCase(3)]
            [TestCase(2)]
            [TestCase(1)]
            public void it_should_increase_quality_by_three_when_there_are_five_days_left(int daysLeft)
            {
                var item = new BackstagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = daysLeft }.UpdateQuality();
                Assert.That(item.Quality, Is.EqualTo(4));
            }

            [Test]
            public void it_should_drop_quality_to_zero_when_sell_in_has_passed()
            {
                var item = new BackstagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 0 }.UpdateQuality();
                Assert.That(item.Quality, Is.EqualTo(0));
            }

            [Test]
            public void sell_in_should_decrement_normally()
            {
                var item = new BackstagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 1 }.UpdateQuality();
                Assert.That(item.SellIn, Is.EqualTo(0));
            }
        }
    }

    public static class TestHelper
    {
        public static Item UpdateQuality(this Item item)
        {
            item.Update();
            return item;
        }
    }
}
