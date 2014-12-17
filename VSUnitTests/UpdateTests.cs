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
            var item = new Item { Name = "standard item", SellIn = 1, Quality = 1 }.UpdateQuality();
            Assert.AreEqual(0, item.SellIn);
        }
    }

    public static class TestHelper
    {
        private static Program program = new Program();
        public static Item UpdateQuality(this Item item)
        {
            return program.UpdateQuality(item);
        }
    }
}
