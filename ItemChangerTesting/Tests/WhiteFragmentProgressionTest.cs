using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;
using ItemChanger.Placements;

namespace ItemChangerTesting.Tests
{
    class WhiteFragmentProgressionTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Room_Charm_Shop, "left1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            ShopPlacement sp = Finder.GetLocation(LocationNames.Salubra).Wrap() as ShopPlacement;
            sp.defaultShopItems = DefaultShopItems.None;
            sp.AddItem(Finder.GetItem(ItemNames.Queen_Fragment));
            sp.AddItem(Finder.GetItem(ItemNames.King_Fragment));
            sp.AddItem(Finder.GetItem(ItemNames.Kingsoul));
            sp.AddItem(Finder.GetItem(ItemNames.Void_Heart));

            yield return sp;
        }
    }
}
