using ItemChanger.StartDefs;

namespace ItemChangerTesting.Tests
{
    class GeoRock420Test : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Deepnest_East_17, "left1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Geo_Rock_Kingdoms_Edge_420_Geo_Rock).Wrap().Add(Finder.GetItem(ItemNames.Arcane_Egg));
            yield return Finder.GetLocation(LocationNames.Geo_Rock_Kingdoms_Edge_Above_420_Geo_Rock).Wrap().Add(Finder.GetItem(ItemNames.Arcane_Egg));
            yield return Finder.GetLocation(LocationNames.Soul_Totem_420_Geo_Rock).Wrap().Add(Finder.GetItem(ItemNames.Arcane_Egg));
        }
    }
}
