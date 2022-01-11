using ItemChanger.StartDefs;

namespace ItemChangerTesting.Tests
{
    class ColosseumTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Room_Colosseum_01, "left1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Charm_Notch_Colosseum).Wrap().Add(args.Items);
            yield return Finder.GetLocation(LocationNames.Pale_Ore_Colosseum).Wrap().Add(args.Items);
        }
    }
}
