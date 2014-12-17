namespace GildedRose.Console
{
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