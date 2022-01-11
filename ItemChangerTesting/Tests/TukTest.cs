namespace ItemChangerTesting.Tests
{
    class TukTest : SimpleTest
    {
        public TukTest() : base(LocationNames.Rancid_Egg_Tuk_Defenders_Crest, "left1") { }

        public override void Start(TestArgs args)
        {
            base.Start(args);
            PlayerData.instance.gotCharm_10 = true;
        }
    }
}
