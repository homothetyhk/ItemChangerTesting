namespace ItemChangerTesting.Tests
{
    public class EggShopTest : Test
    {
        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            Random rng = new();
            AbstractPlacement p = Finder.GetLocation(LocationNames.Egg_Shop).Wrap();
            foreach (var i in args.Items)
            {
                i.AddTag<CostTag>().Cost = new ItemChanger.Modules.CumulativeRancidEggCost(rng.Next(3));
                p.Add(i);
            }
            yield return p;

            yield return Finder.GetLocation(LocationNames.Salubra).Wrap().Add(Finder.GetItem(ItemNames.Rancid_Egg)).Add(Finder.GetItem(ItemNames.Rancid_Egg)).Add(Finder.GetItem(ItemNames.Rancid_Egg));
        }
    }
}
