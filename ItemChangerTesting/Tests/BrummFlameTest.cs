using ItemChanger.Items;

namespace ItemChangerTesting.Tests
{
    class BrummFlameTest : SimpleTest
    {
        public BrummFlameTest() : base(ItemChanger.LocationNames.Grimmkin_Flame_Brumm, "left1") { }

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            foreach (var p in base.GetPlacements(args)) yield return p;
            AbstractItem gc = Finder.GetItem(ItemNames.Grimmchild1);
            gc.AddTag<ItemChanger.Tags.EquipCharmOnGiveTag>();
            yield return Finder.GetLocation(LocationNames.Start).Wrap()
                .Add(gc)
                .Add(new IntItem
                {
                    amount = 3,
                    fieldName = nameof(PlayerData.grimmChildLevel),
                });
        }
    }
}
