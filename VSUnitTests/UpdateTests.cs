using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VSUnitTests
{
    [TestClass]
    public class UpdateTests
    {
        [TestMethod]
        public void StandardItemSellInShouldDecreaseByOneAfterOneDayUpdate()
        {
            var item = new StandardItem { Name = "standard item", SellIn = 1, Quality = 1 };
            item.Update();
            Assert.AreEqual(0, item.SellIn);
        }

        [TestMethod]
        public void BackstagePassesShouldIncreaseQualityWhenConcertIsIn11Days()
        {
            var item = new BackstagePassItem { Name = "back stage pass", SellIn = 11, Quality = 40 };
            item.Update();
            Assert.AreEqual(41, item.Quality);
        }

        [TestMethod]
        public void BackstagePassesShouldIncreaseQualityWhenConcertIsIn7Days()
        {
            var item = new BackstagePassItem { Name = "back stage pass", SellIn = 7, Quality = 40 };
            item.Update();
            Assert.AreEqual(42, item.Quality);
        }

        [TestMethod]
        public void BackstagePassesShouldIncreaseQualityWhenConcertIsIn3Days()
        {
            var item = new BackstagePassItem { Name = "back stage pass", SellIn = 3, Quality = 40 };
            item.Update();
            Assert.AreEqual(43, item.Quality);
        }

        [TestMethod]
        public void BackstagePassesShouldLooseAllQualityWhenExpired()
        {
            var item = new BackstagePassItem { Name = "back stage pass", SellIn = 0, Quality = 40 };
            item.Update();

            Assert.AreEqual(0, item.Quality);
        }

        [TestMethod]
        public void ConjuredItemQualityShouldDecreaseTwiceAsFastAsStandardItem()
        {
            var sellin = 10;
            var quality = 40;
            var item = new StandardItem { Name = "standard item", SellIn = sellin, Quality = quality };
            var conjureItem = new ConjuredItem { Name = "conjured item", SellIn = sellin, Quality = quality };


            StandardVersusConjuredQualityDegradationBeforeSellInIsZero(item, conjureItem);
            StandardVersusConjuredQualityDegradationAfterSellInIsZero(item, conjureItem);
        }

        private static void StandardVersusConjuredQualityDegradationBeforeSellInIsZero(StandardItem item,
            ConjuredItem conjureItem)
        {
            var sellin = 10;
            var itemQuality = item.Quality;
            var conjuredItemQuality = conjureItem.Quality;

            while (sellin-- > 0)
            {
                item.Update();
                conjureItem.Update();
                Assert.AreEqual(itemQuality - 1, item.Quality);
                Assert.AreEqual(conjuredItemQuality - 2, conjureItem.Quality);

                itemQuality--;
                conjuredItemQuality -= 2;
            }
        }

        private static void StandardVersusConjuredQualityDegradationAfterSellInIsZero(StandardItem item,
            ConjuredItem conjureItem)
        {
            var sellin = 0;
            var itemQuality = item.Quality;
            var conjuredItemQuality = conjureItem.Quality;
            while (sellin-- > -10)
            {
                item.Update();
                conjureItem.Update();
                Assert.AreEqual(itemQuality - 2, item.Quality);
                Assert.AreEqual(conjuredItemQuality - 4, conjureItem.Quality);

                itemQuality -= 2;
                conjuredItemQuality -= 4;
            }
        }
    }
}
