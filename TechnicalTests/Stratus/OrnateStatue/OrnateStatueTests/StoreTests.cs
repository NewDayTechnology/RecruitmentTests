using FluentAssertions;
using OrnateStatueStore;

namespace OrnateStatueTests;

public class StoreTests
{
    [Fact]
    public void A_standard_product_should_decrease_sellin_and_quality()
    {
        var items = new List<Item>
        {
            new () { Name = "foo", SellIn = 5, Quality = 5 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].SellIn.Should().Be(4);
        items[0].Quality.Should().Be(4);
    }
}