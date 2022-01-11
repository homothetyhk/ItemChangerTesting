namespace ItemChangerTesting.Tests
{
    class CollectorTest : Test
    {
        public override StartDef StartDef => new StartDef
        {
            X = 25f, Y = 120f,
            SceneName = SceneNames.Ruins2_11,
        };

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Grub_Collector_1).Wrap().Add(args.Items);
            yield return Finder.GetLocation(LocationNames.Grub_Collector_2).Wrap().Add(Finder.GetItem(ItemNames.Geo_Rock_Abyss));
            yield return Finder.GetLocation(LocationNames.Grub_Collector_3).Wrap().Add(new[] { Finder.GetItem(ItemNames.Geo_Chest_Watcher_Knights), Finder.GetItem(ItemNames.Great_Slash) });
            yield return Finder.GetLocation(LocationNames.Collectors_Map).Wrap().Add(Finder.GetItem(ItemNames.Godtuner));
        }
    }
}
