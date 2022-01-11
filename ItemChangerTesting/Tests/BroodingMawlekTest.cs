namespace ItemChangerTesting.Tests
{
    class BroodingMawlekTest : SimpleTest
    {
        public BroodingMawlekTest() : base(LocationNames.Mask_Shard_Brooding_Mawlek, "left1") { }

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            var p = base.GetPlacements(args).First();
            yield return p;
        }

    }
}
