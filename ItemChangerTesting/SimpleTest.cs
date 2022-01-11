using ItemChanger.StartDefs;

namespace ItemChangerTesting
{
    public abstract class SimpleTest : Test
    {
        public readonly string location;
        public readonly string entryGateName;

        public SimpleTest(string location, string entryGateName)
        {
            this.location = location;
            this.entryGateName = entryGateName;
        }

        public override StartDef StartDef => TransitionBasedStartDef.FromGate(Finder.GetLocation(location).sceneName, entryGateName);

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(location).Wrap().Add(args.Items);
        }
    }
}
