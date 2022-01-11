namespace ItemChangerTesting.Tests
{
    class JunkPitTest : Test
    {
        public override StartDef StartDef => new StartDef 
        {
            X = 50.8f,
            Y = 15.9f,
            SceneName = SceneNames.GG_Waterways,
            MapZone = (int)GlobalEnums.MapZone.GODSEEKER_WASTE,
        };

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Godtuner).Wrap()
                .Add(Finder.GetItem(ItemNames.Mimic_Grub), Finder.GetItem(ItemNames.Lumafly_Escape), Finder.GetItem(ItemNames.Elevator_Pass));
            yield return Finder.GetLocation(LocationNames.Geo_Chest_Junk_Pit_1).Wrap().Add(Finder.GetItem(ItemNames.Simple_Key));
            yield return Finder.GetLocation(LocationNames.Geo_Chest_Junk_Pit_2).Wrap().Add(Finder.GetItem(ItemNames.Simple_Key));
            yield return Finder.GetLocation(LocationNames.Geo_Chest_Junk_Pit_3).Wrap().Add(Finder.GetItem(ItemNames.Geo_Chest_Watcher_Knights));
            yield return Finder.GetLocation(LocationNames.Geo_Chest_Junk_Pit_5).Wrap().Add(Finder.GetItem(ItemNames.Soul_Totem_B));
            yield return Finder.GetLocation(LocationNames.Lumafly_Escape_Junk_Pit_Chest_4).Wrap().Add(Finder.GetItem(ItemNames.Greenpath_Map));
        }
    }
}
