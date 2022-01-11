using ItemChanger.StartDefs;

namespace ItemChangerTesting.Tests
{
    class NailmastersGloryTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate("Room_ruinhouse", "left1");
        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Nailmasters_Glory).Wrap();
        }

        public override void Start(TestArgs args)
        {
            PlayerData.instance.hasUpwardSlash = PlayerData.instance.hasDashSlash = PlayerData.instance.hasCyclone = true; 
            base.Start(args);   
        }

    }
}
