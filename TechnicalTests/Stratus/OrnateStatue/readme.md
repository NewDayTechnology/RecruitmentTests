# Ornate Statue Requirements Specification

Hi and welcome to the Ornate Statue store. We only the finest goods, however our goods are 
constantly degrading in `Quality` as they approach their sell by date.

We have a system in place that updates our inventory for us. Your task is to add the new feature to our system so that
we can begin selling a new category of items. First an introduction to our system:

- All `items` have a `SellIn` value which denotes the number of days we have to sell the `items`
- All `items` have a `Quality` value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

- Once the sell by date has passed, `Quality` degrades twice as fast
- The `Quality` of an item is never negative
- __"Aged Brie"__ actually increases in `Quality` the older it gets
- The `Quality` of an item is never more than `50`
- __"Diamond ring"__, being a valuable item, never has to be sold or decreases in `Quality`
- __"Backstage passes"__, like aged brie, increases in `Quality` as its `SellIn` value approaches;
	- `Quality` increases by `2` when there are `10` days or less and by `3` when there are `5` days or less but
	- `Quality` drops to `0` after the concert

We have recently signed a supplier of fresh items. This requires an update to our system:

- __"Fresh apples"__ items degrade in `Quality` twice as fast as normal items

Feel free to make any changes to the `UpdateQuality` method and add any new code as long as everything
still works correctly. However, do not alter the `Item` class or `Items` property.

Just for clarification, an item can never have its `Quality` increase above `50`, however __"Diamond ring"__ is a
legendary item and as such its `Quality` is `80` and it never alters.