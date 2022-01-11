using ItemChanger.StartDefs;

namespace ItemChangerTesting.Tests
{
    public class NewTotemTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Deepnest_East_07, "bot1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Wanderers_Journal_Kingdoms_Edge_Entrance).Wrap().Add(Finder.GetItem(ItemNames.Soul_Totem_B)).Add(args.Items);
        }
    }
}
