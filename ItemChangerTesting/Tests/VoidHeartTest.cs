namespace ItemChangerTesting.Tests
{
    class VoidHeartTest : Test
    {
        public override StartDef StartDef => new StartDef { SceneName = SceneNames.Abyss_15, X = 11f, Y = 96.4f, MapZone = (int)GlobalEnums.MapZone.ABYSS_DEEP };

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Void_Heart).Wrap().Add(args.Items);
        }
    }
}
