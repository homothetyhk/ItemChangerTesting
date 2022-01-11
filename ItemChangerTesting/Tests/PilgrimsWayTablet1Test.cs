namespace ItemChangerTesting.Tests
{
    class PilgrimsWayTablet1Test : SimpleTest
    {
        public PilgrimsWayTablet1Test() : base(LocationNames.Lore_Tablet_Pilgrims_Way_1, "right1") { }

        public override void Start(TestArgs args)
        {
            base.Start(args);
            PlayerData.instance.crossroadsInfected = true;
            //PlayerData.instance.visitedCrossroads = true;
        }
    }
}
