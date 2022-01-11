using ItemChanger.StartDefs;

namespace ItemChangerTesting.Tests
{
    class DreamNailTest : SimpleTest
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.RestingGrounds_04, "left1");
        public DreamNailTest() : base(LocationNames.Dream_Nail, "left1") { }
    }
}
