namespace GildedRose.Console
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public virtual void Update()
        {
            // Why update qualilty before sell in : because update depends upon sellin value
            UpdateQuality();
            UpdateSellIn();
            
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
}