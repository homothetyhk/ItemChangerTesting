using ItemChanger.Placements;

namespace ItemChangerTesting.Tests
{
    class DivineTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Grimm_Divine, "left1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            ExistingContainerPlacement fh = (ExistingContainerPlacement)Finder.GetLocation(LocationNames.Unbreakable_Heart).Wrap().Add(Finder.GetItem(ItemNames.Grub));
            fh.Cost = Cost.NewGeoCost(100);
            yield return fh;
            ExistingContainerPlacement fg = (ExistingContainerPlacement)Finder.GetLocation(LocationNames.Unbreakable_Greed).Wrap().Add(Finder.GetItem(ItemNames.Grubsong));
            fh.Cost = Cost.NewGeoCost(100);
            yield return fg;
            ExistingContainerPlacement fs = (ExistingContainerPlacement)Finder.GetLocation(LocationNames.Unbreakable_Strength).Wrap().Add(Finder.GetItem(ItemNames.Geo_Rock_Outskirts420));
            fh.Cost = Cost.NewGeoCost(100);
            yield return fs;
            AbstractItem c23 = Finder.GetItem(ItemNames.Fragile_Heart);
            c23.AddTag<ItemChanger.Tags.EquipCharmOnGiveTag>();
            yield return Finder.GetLocation(LocationNames.Start).Wrap()
                .Add(c23).Add(Finder.GetItem(ItemNames.Fragile_Greed)).Add(Finder.GetItem(ItemNames.Fragile_Strength));
        }
    }
}
