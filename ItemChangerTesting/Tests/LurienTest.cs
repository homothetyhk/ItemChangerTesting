using ItemChanger.StartDefs;

namespace ItemChangerTesting.Tests
{
    class LurienTest : SimpleTest
    {
        public LurienTest() : base(ItemChanger.LocationNames.Lurien, "bot1") { }
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Ruins2_Watcher_Room, "bot1");

        public override void Start(TestArgs args)
        {
            base.Start(args);
            PlayerData.instance.gotCharm_40 = PlayerData.instance.equippedCharm_40 = true;
            PlayerData.instance.grimmChildLevel = 2;
        }
    }
}
