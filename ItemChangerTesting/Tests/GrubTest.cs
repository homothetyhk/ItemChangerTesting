namespace ItemChangerTesting.Tests
{
    class GrubTest : SimpleTest
    {
        public GrubTest() : base(ItemChanger.LocationNames.Grub_Crystal_Peak_Below_Chest, "top1") { }

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Grub_Crystal_Peak_Below_Chest).Wrap().Add(Finder.GetItem(ItemNames.Grub));
        }

    }
}
