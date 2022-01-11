namespace ItemChangerTesting.Tests
{
    public class JournalEntryTest : Test
    {
        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Salubra).Wrap().Add(Finder.GetItem(ItemNames.Hunters_Journal), Finder.GetItem(ItemNames.Journal_Entry_Void_Tendrils)
                , Finder.GetItem(ItemNames.Journal_Entry_Charged_Lumafly)
                , Finder.GetItem(ItemNames.Journal_Entry_Goam)
                , Finder.GetItem(ItemNames.Journal_Entry_Garpede)
                , Finder.GetItem(ItemNames.Journal_Entry_Seal_of_Binding));

            yield return Finder.GetLocation(LocationNames.Hunters_Journal).Wrap().Add(Finder.GetItem(ItemNames.Greenpath_Map));
            yield return Finder.GetLocation(LocationNames.Journal_Entry_Void_Tendrils).Wrap().Add(Finder.GetItem(ItemNames.Ancient_Basin_Map));
            yield return Finder.GetLocation(LocationNames.Journal_Entry_Charged_Lumafly).Wrap().Add(Finder.GetItem(ItemNames.Grub));
            yield return Finder.GetLocation(LocationNames.Journal_Entry_Goam).Wrap().Add(Finder.GetItem(ItemNames.Geo_Rock_Abyss));
            yield return Finder.GetLocation(LocationNames.Journal_Entry_Garpede).Wrap().Add(Finder.GetItem(ItemNames.Cyclone_Slash));
            yield return Finder.GetLocation(LocationNames.Journal_Entry_Seal_of_Binding).Wrap().Add(Finder.GetItem(ItemNames.Great_Slash));
        }
    }
}
