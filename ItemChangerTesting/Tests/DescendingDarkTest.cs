namespace ItemChangerTesting.Tests
{
    class DescendingDarkTest : SimpleTest
    {
        public DescendingDarkTest() : base(ItemChanger.LocationNames.Descending_Dark, "left1") { }

        public override void Start(TestArgs args)
        {
            base.Start(args);
            GameManager.instance.sceneData.SaveMyState(new PersistentBoolData
            {
                sceneName = ItemChanger.SceneNames.Mines_35,
                activated = true,
                id = "One Way Wall",
                semiPersistent = false,
            });
        }

    }
}
