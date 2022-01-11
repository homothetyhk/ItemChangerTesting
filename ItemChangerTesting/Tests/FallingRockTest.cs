using ItemChanger.Items;
using ItemChanger.Locations;

namespace ItemChangerTesting.Tests
{
    public class FallingRockTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Crossroads_08, "left2");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            return Finder.GetFullLocationList().Values.Where(l => l.sceneName == SceneNames.Crossroads_08)
                .Select(l => l.Wrap().Add(Finder.GetItem(ItemNames.Geo_Rock_Deepnest)));
        }
    }
}
