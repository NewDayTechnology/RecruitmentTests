using FluentAssertions;
using OrnateStatueStore;

namespace OrnateStatueTests;

public class StoreTests
{
    const string StandardProduct = "Set of teacups";
    const string AgedBrie = "Aged Brie";
    const string DiamondRing = "Diamond ring";
    const string BackstagePasses = "Backstage passes to concert";
    const string FreshApples = "Fresh apples";      

    [Theory]
    [InlineData(StandardProduct)]
    [InlineData(FreshApples)]
    public void Quality_should_never_be_negative(string name)
    {
        var items = new List<Item>
        {
            new () { Name = name, SellIn = 5, Quality = 0 },
            new () { Name = name, SellIn = 5, Quality = 1 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items.Should().AllSatisfy(x => x.Quality.Should().Be(0) );
    }

    [Theory]
    [InlineData(StandardProduct)]
    [InlineData(AgedBrie)]
    [InlineData(BackstagePasses)]
    [InlineData(FreshApples)]
    public void SellIn_should_decrease(string name)
    {
        var items = new List<Item>
        {
            new () { Name = name, SellIn = 5, Quality = 5 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].SellIn.Should().Be(4);
    }

    [Fact]
    public void A_standard_product_should_decrease_quality()
    {
        var items = new List<Item>
        {
            new () { Name = StandardProduct, SellIn = 5, Quality = 5 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].Quality.Should().Be(4);
    }

    [Fact]
    public void A_standard_product_should_decrease_quality_twice_as_fast()
    {
        var items = new List<Item>
        {
            new () { Name = StandardProduct, SellIn = -1, Quality = 5 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].Quality.Should().Be(3);
    }

    [Fact]
    public void AgedBrie_increases_in_quality()
    {
        var items = new List<Item>
        {
            new () { Name = AgedBrie, SellIn = 5, Quality = 5 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].Quality.Should().Be(6);
    }

    [Fact]
    public void AgedBrie_quality_doesnt_go_above_fifty()
    {
        var items = new List<Item>
        {
            new () { Name = AgedBrie, SellIn = 5, Quality = 50 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].Quality.Should().Be(50);
    }

    [Fact]
    public void DiamondRing_does_not_change_quality()
    {
        var items = new List<Item>
        {
            new () { Name = DiamondRing, SellIn = 5, Quality = 5 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].Quality.Should().Be(5);
    }

    [Fact]
    public void DiamondRing_does_not_need_to_be_sold()
    {
        var items = new List<Item>
        {
            new () { Name = DiamondRing, SellIn = 5, Quality = 5 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].SellIn.Should().Be(5);
    }

    [Fact]
    public void BackstagePasses_increases_in_quality_1()
    {
        var items = new List<Item>
        {
            new () { Name = BackstagePasses, SellIn = 50, Quality = 5 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].Quality.Should().Be(6);
    }

    [Fact]
    public void BackstagePasses_increases_in_quality_2_10Days()
    {
        var items = new List<Item>
        {
            new () { Name = BackstagePasses, SellIn = 10, Quality = 5 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].Quality.Should().Be(7);
    }

    [Fact]
    public void BackstagePasses_increases_in_quality_3_5Days()
    {
        var items = new List<Item>
        {
            new () { Name = BackstagePasses, SellIn = 5, Quality = 5 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].Quality.Should().Be(8);
    }

    [Fact]
    public void BackstagePasses_zero_quality_at_zero_days()
    {
        var items = new List<Item>
        {
            new () { Name = BackstagePasses, SellIn = 0, Quality = 5 },
        };
        var store = new Store(items);
        store.UpdateQuality();

        items[0].Quality.Should().Be(0);
    }
}