namespace ItemChangerTesting.Tests
{
    internal class HowlingWraithsTest : SimpleTest
    {
        public HowlingWraithsTest() : base(LocationNames.Howling_Wraiths, "left1") { }
        public override StartDef StartDef => new() { SceneName = SceneNames.Room_Fungus_Shaman, X = 126.2f, Y = 9.4f, };
    }
}
