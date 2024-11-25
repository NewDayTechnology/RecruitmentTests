using OrnateStatueStore;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the store!");

        var items = new List<Item>
        {
            new (){Name = "Ornamental vase", SellIn = 10, Quality = 20},
            new (){Name = "Aged Brie", SellIn = 2, Quality = 0},
            new () {Name = "Set of teacups", SellIn = 5, Quality = 7},
            new () {Name = "Diamond ring", SellIn = 0, Quality = 80},
            new () {Name = "Diamond ring", SellIn = -1, Quality = 80},
            new ()
            {
                Name = "Backstage passes to concert",
                SellIn = 15,
                Quality = 20
            },
            new ()
            {
                Name = "Backstage passes to concert",
                SellIn = 10,
                Quality = 49
            },
            new ()
            {
                Name = "Backstage passes to concert",
                SellIn = 5,
                Quality = 49
            },
            // this Fresh apples does not work properly yet
            new Item {Name = "Fresh apples", SellIn = 3, Quality = 17}
        };

        var store = new Store(items);
        var days = args.Length > 0 ? int.Parse(args[0]) + 1 : 2;

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");
            store.UpdateQuality();
        }
    }
}