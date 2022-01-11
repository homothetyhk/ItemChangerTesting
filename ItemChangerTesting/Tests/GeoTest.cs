using ItemChanger.StartDefs;

namespace ItemChangerTesting.Tests
{
    class GeoTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Crossroads_ShamanTemple, "left1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Vengeful_Spirit).Wrap().Add(args.Items);
        }
    }
}
