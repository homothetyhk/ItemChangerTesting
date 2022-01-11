namespace ItemChangerTesting.Tests
{
    class WorldSenseTest : Test
    {
        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.World_Sense).Wrap().Add(Finder.GetItem(ItemNames.Geo_Rock_Abyss));
            yield return Finder.GetLocation(LocationNames.Lore_Tablet_World_Sense).Wrap().Add(args.Items);
        }
    }
}
