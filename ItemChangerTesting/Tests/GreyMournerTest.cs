namespace ItemChangerTesting.Tests
{
    class GreyMournerTest : SimpleTest
    {
        public GreyMournerTest() : base(ItemChanger.LocationNames.Mask_Shard_Grey_Mourner, "left1") { }

        public override void Start(TestArgs args)
        {
            base.Start(args);
            PlayerData.instance.xunFlowerGiven = true;
        }
    }
}
