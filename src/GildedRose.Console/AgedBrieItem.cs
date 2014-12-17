namespace GildedRose.Console
{
    public class AgedBrieItem : Item
    {
        protected override void UpdateQuality()
        {
            if (Quality < 50)
                Quality++;
        }
    }
}