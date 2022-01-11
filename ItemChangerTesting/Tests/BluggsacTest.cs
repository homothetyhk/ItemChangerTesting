namespace ItemChangerTesting.Tests
{
    class BluggsacTest : Test
    {
        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Rancid_Egg_Queens_Gardens).Wrap().Add(Finder.GetItem(ItemNames.Crossroads_Map));
            yield return Finder.GetLocation(LocationNames.Rancid_Egg_Blue_Lake).Wrap().Add(Finder.GetItem(ItemNames.Greenpath_Map));
            yield return Finder.GetLocation(LocationNames.Rancid_Egg_Crystal_Peak_Dive_Entrance).Wrap().Add(Finder.GetItem(ItemNames.Fog_Canyon_Map));
            yield return Finder.GetLocation(LocationNames.Rancid_Egg_Crystal_Peak_Tall_Room).Wrap().Add(Finder.GetItem(ItemNames.Fungal_Wastes_Map));
            yield return Finder.GetLocation(LocationNames.Rancid_Egg_Beasts_Den).Wrap().Add(Finder.GetItem(ItemNames.City_of_Tears_Map));
            yield return Finder.GetLocation(LocationNames.Rancid_Egg_Dark_Deepnest).Wrap().Add(Finder.GetItem(ItemNames.Crystal_Peak_Map));
            yield return Finder.GetLocation(LocationNames.Rancid_Egg_Near_Quick_Slash).Wrap().Add(Finder.GetItem(ItemNames.Ancient_Basin_Map));
            yield return Finder.GetLocation(LocationNames.Rancid_Egg_Waterways_East).Wrap().Add(Finder.GetItem(ItemNames.Kingdoms_Edge_Map));
            yield return Finder.GetLocation(LocationNames.Rancid_Egg_Waterways_Main).Wrap().Add(Finder.GetItem(ItemNames.Queens_Gardens_Map));
            yield return Finder.GetLocation(LocationNames.Rancid_Egg_Waterways_West_Bluggsac).Wrap().Add(Finder.GetItem(ItemNames.Howling_Cliffs_Map));
        }
    }
}
