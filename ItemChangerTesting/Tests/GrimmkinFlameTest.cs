namespace ItemChangerTesting.Tests
{
    class GrimmkinFlameTest : Test
    {
        public override StartDef StartDef => ItemChanger.StartDefs.TransitionBasedStartDef.FromGate(SceneNames.Grimm_Main_Tent, "left1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation("Grimmchild").Wrap().Add(Finder.GetItem(ItemNames.Grimmkin_Flame), Finder.GetItem(ItemNames.Grimmkin_Flame), Finder.GetItem(ItemNames.Grimmkin_Flame), Finder.GetItem(ItemNames.Grimmkin_Flame), Finder.GetItem(ItemNames.Grimmkin_Flame));
            yield return Finder.GetLocation(LocationNames.Charm_Notch_Grimm).Wrap()
                .Add(Finder.GetItem(ItemNames.Grimmkin_Flame), Finder.GetItem(ItemNames.Grimmkin_Flame), Finder.GetItem(ItemNames.Grimmkin_Flame), Finder.GetItem(ItemNames.Grimmkin_Flame));
            yield return Finder.GetLocation("Start").Wrap().Add(Finder.GetItem(ItemNames.Grimmchild1), Finder.GetItem(ItemNames.Grimmkin_Flame));
        }

        public override void Start(TestArgs args)
        {
            base.Start(args);
        }

    }
}
