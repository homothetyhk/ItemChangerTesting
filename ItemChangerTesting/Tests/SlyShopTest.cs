using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;
using ItemChanger.Placements;

namespace ItemChangerTesting.Tests
{
    class SlyShopTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Room_shop, "left1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            var sly1 = Finder.GetLocation(LocationNames.Sly).Wrap() as ShopPlacement;
            var sly2 = Finder.GetLocation(LocationNames.Sly).Wrap() as ShopPlacement;
            var sly_key1 = Finder.GetLocation(LocationNames.Sly_Key).Wrap() as ShopPlacement;
            var sly_key2 = Finder.GetLocation(LocationNames.Sly_Key).Wrap() as ShopPlacement;

            sly_key1.defaultShopItems = sly1.defaultShopItems = DefaultShopItems.SlyCharms | DefaultShopItems.SlyRancidEgg | DefaultShopItems.SlyKeyElegantKey;
            sly_key2.defaultShopItems = sly2.defaultShopItems = DefaultShopItems.SlyRancidEgg | DefaultShopItems.SlyKeyElegantKey;

            var wk = Finder.GetItem(ItemNames.Geo_Chest_Watcher_Knights);
            var grub = Finder.GetItem(ItemNames.Grub);
            var shopkey = Finder.GetItem(ItemNames.Shopkeepers_Key);
            var dive = Finder.GetItem(ItemNames.Desolate_Dive);
            var cyclone = Finder.GetItem(ItemNames.Cyclone_Slash);

            sly1.AddItemWithCost(wk, null);
            sly1.AddItemWithCost(grub, 100);
            sly2.AddItemWithCost(shopkey, Cost.NewGrubCost(1));
            sly_key1.AddItem(dive);
            sly_key2.AddItem(cyclone);

            yield return sly1;
            yield return sly_key1;
            yield return sly2;
            yield return sly_key2;
        }

        public override void Start(TestArgs args)
        {
            base.Start(args);
            PlayerData.instance.SetBool(nameof(PlayerData.slyRescued), true);
            ItemChanger.Internal.Ref.WORLD.slyRescued = true;
        }
    }
}
