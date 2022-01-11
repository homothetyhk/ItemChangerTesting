namespace ItemChangerTesting.Tests
{
    class GrubMimicComparison : Test
    {
        public override StartDef StartDef => new StartDef { SceneName = SceneNames.Fungus2_14, X = 18.5f, Y = 20.4f };

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Left_Mantis_Claw).Wrap().Add(Finder.GetItem(ItemNames.Grub));
            yield return Finder.GetLocation(LocationNames.Right_Mantis_Claw).Wrap().Add(Finder.GetItem(ItemNames.Mimic_Grub));
        }
    }
}
