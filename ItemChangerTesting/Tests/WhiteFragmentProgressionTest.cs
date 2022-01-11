using ItemChanger.Placements;
using ItemChanger.StartDefs;

namespace ItemChangerTesting.Tests
{
    class WhiteFragmentProgressionTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Room_Charm_Shop, "left1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            ShopPlacement sp = Finder.GetLocation(LocationNames.Salubra).Wrap() as ShopPlacement;
            sp.defaultShopItems = DefaultShopItems.None;
            sp.Add(Finder.GetItem(ItemNames.Queen_Fragment));
            sp.Add(Finder.GetItem(ItemNames.King_Fragment));
            sp.Add(Finder.GetItem(ItemNames.Kingsoul));
            sp.Add(Finder.GetItem(ItemNames.Void_Heart));

            yield return sp;
        }
    }
}
