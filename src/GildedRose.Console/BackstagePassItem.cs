namespace GildedRose.Console
{
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
}