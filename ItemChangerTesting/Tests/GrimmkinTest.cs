using ItemChanger.Items;

namespace ItemChangerTesting.Tests
{
    class GrimmkinTest : SimpleTest
    {
        public GrimmkinTest() : base(ItemChanger.LocationNames.Grimmkin_Flame_Greenpath, "top1") { }

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            foreach (var p in base.GetPlacements(args)) yield return p;
            AbstractItem gc = Finder.GetItem(ItemNames.Grimmchild1);
            gc.AddTag<ItemChanger.Tags.EquipCharmOnGiveTag>();
            yield return Finder.GetLocation(LocationNames.Start).Wrap()
                .Add(gc);
        }
    }
}
