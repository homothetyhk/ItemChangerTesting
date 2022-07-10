using ItemChanger.Extensions;
using ItemChanger.Locations;

namespace ItemChangerTesting.Tests
{
    class SwimTest : Test
    {
        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            return new ObjectLocation
            {
                name = "a",
                sceneName = SceneNames.Ruins2_07,
                objectName = "broken_bench_02"
            }.Wrap().Add(Finder.GetItem(ItemNames.Swim)).Yield();
        }

        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Ruins2_07, "left1");
        public override void Start(TestArgs args)
        {
            base.Start(args);
            var i = ItemChanger.Internal.Ref.Settings.Placements["Start"].Items;
            i.RemoveAll(a => a.name == ItemNames.Monarch_Wings);
            i.RemoveAll(a => a.name == ItemNames.Mantis_Claw);
            i.Add(Finder.GetItem(ItemNames.Left_Mantis_Claw));
        }
    }
}
