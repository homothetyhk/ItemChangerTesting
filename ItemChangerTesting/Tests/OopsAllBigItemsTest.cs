using ItemChanger.StartDefs;

namespace ItemChangerTesting.Tests
{
    public class OopsAllBigItemsTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Cliffs_05, "left1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Jonis_Blessing).Wrap()
                .Add(Finder.GetFullItemList().Values.Where(i => i.UIDef is ItemChanger.UIDefs.BigUIDef).Select(i =>
                {
                    if (i.tags != null) i.tags = i.tags.Where(t => t is not ItemChanger.Tags.IItemModifierTag).ToList();
                    return i;
                }).Skip(5).ToArray());
        }
    }
}
