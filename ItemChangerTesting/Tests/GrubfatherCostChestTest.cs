using ItemChanger.Locations;
using ItemChanger.Placements;
using ItemChanger.StartDefs;

namespace ItemChangerTesting.Tests
{
    public class GrubfatherCostChestTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Crossroads_38, "right1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            var p = new CostChestPlacement("Grubfather")
            {
                chestLocation = Chest,
                tabletLocation = Tablet,
            };
            Random rng = new Random();
            p.Add(args.Items.Apply(i => i.AddTag<CostTag>().Cost = Cost.NewGrubCost(rng.Next(0, 5))));
            yield return p;

            var p2 = new MutablePlacement("Grubs")
            {
                Location = Finder.GetLocation(LocationNames.Hallownest_Seal_Grubs) as CoordinateLocation,
                containerType = Container.Chest,
            };
            p2.Add(Repeat(Finder.GetItem(ItemNames.Grub), 4));
            yield return p2;
        }

        static CoordinateLocation Chest => Finder.GetLocation(LocationNames.Grubberflys_Elegy) as CoordinateLocation;
        static CoordinateLocation Tablet => Finder.GetLocation(LocationNames.Mask_Shard_5_Grubs) as CoordinateLocation;
    }
}
