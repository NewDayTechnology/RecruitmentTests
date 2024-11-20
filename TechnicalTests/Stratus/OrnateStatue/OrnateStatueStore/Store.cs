namespace OrnateStatueStore;

public class Store(IList<Item> items)
{
    public void UpdateQuality()
    {
        for (var i = 0; i < items.Count; i++)
        {
            if (items[i].Name != "Aged Brie" && items[i].Name != "Backstage passes to concert")
            {
                if (items[i].Quality > 0)
                {
                    if (items[i].Name != "Diamond ring")
                    {
                        items[i].Quality = items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (items[i].Quality < 50)
                {
                    items[i].Quality = items[i].Quality + 1;

                    if (items[i].Name == "Backstage passes to concert")
                    {
                        if (items[i].SellIn < 11)
                        {
                            if (items[i].Quality < 50)
                            {
                                items[i].Quality = items[i].Quality + 1;
                            }
                        }

                        if (items[i].SellIn < 6)
                        {
                            if (items[i].Quality < 50)
                            {
                                items[i].Quality = items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            if (items[i].Name != "Diamond ring")
            {
                items[i].SellIn = items[i].SellIn - 1;
            }

            if (items[i].SellIn < 0)
            {
                if (items[i].Name != "Aged Brie")
                {
                    if (items[i].Name != "Backstage passes to concert")
                    {
                        if (items[i].Quality > 0)
                        {
                            if (items[i].Name != "Diamond ring")
                            {
                                items[i].Quality = items[i].Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        items[i].Quality = items[i].Quality - items[i].Quality;
                    }
                }
                else
                {
                    if (items[i].Quality < 50)
                    {
                        items[i].Quality = items[i].Quality + 1;
                    }
                }
            }
        }
    }
}
