using GlobalEnums;
using ItemChanger.Items;
using ItemChanger.Locations;
using ItemChanger.Placements;
using ItemChanger.Tags;
using ItemChanger.UIDefs;

namespace ItemChangerTesting.Tests
{
    /// <summary>
    /// Tests that custom a custom shop can be placed, with various shops sharing an NPC. Also
    /// tests most cosmetic features, including<br/>
    /// - cost displayers with different primary and nonprimary costs are tested along with nested and unnested costs<br/>
    /// - custom figureheads<br/>
    /// - out of stock dialog
    /// </summary>
    class CustomShopFlukeTest : Test
    {
        public override StartDef StartDef => new StartDef()
        {
            SceneName = SceneNames.Room_GG_Shortcut,
            X = 101.5f,
            Y = 69.4f,
            MapZone = (int)MapZone.WATERWAYS
        };

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            CustomShopLocation flukeShop = new()
            {
                name = "Fluke_Shop",
                sceneName = SceneNames.Room_GG_Shortcut,
                objectName = "Fluke Hermit",
                fsmName = "npc_control",
                outOfStockConvo = new BoxedString("Wow!<page>You sure did buy a lot of stuff."),
                dungDiscount = false,
                facingDirection = FacingDirection.Left,
                figureheadSprite = new ItemChangerSprite("Charms.11"),
            };
            CustomShopLocation flukerShop = new()
            {
                name = "Fluker_Shop",
                sceneName = SceneNames.Room_GG_Shortcut,
                objectName = "Fluke Hermit",
                fsmName = "npc_control",
                dungDiscount = false,
                costDisplayerSelectionStrategy = new SingleCostDisplayerSelectionStrategy()
                {
                    CostDisplayer = new PDIntCostDisplayer()
                    {
                        Cumulative = true,
                        FieldName = nameof(PlayerData.grubsCollected),
                        CustomCostSprite = new ItemChangerSprite("ShopIcons.Grub")
                    }
                },
                requiredPlayerDataBool = nameof(PlayerData.gotCharm_11),
                facingDirection = FacingDirection.Left,
                figureheadSprite = new ItemChangerSprite("Charms.11"),
            };
            CustomShopLocation flukestShop = new()
            {
                name = "Flukest_Shop",
                sceneName = SceneNames.Room_GG_Shortcut,
                objectName = "Fluke Hermit",
                fsmName = "npc_control",
                dungDiscount = false,
                facingDirection = FacingDirection.Left,
                figureheadSprite = new ItemChangerSprite("Charms.11"),
            };

            ShopPlacement hermit = flukeShop.Wrap() as ShopPlacement;
            ShopPlacement hermit2 = flukerShop.Wrap() as ShopPlacement;
            ShopPlacement hermit3 = flukestShop.Wrap() as ShopPlacement;

            hermit.AddItemWithCost(Finder.GetItem(ItemNames.Flukenest), null);
            hermit.AddItemWithCost(Finder.GetItem(ItemNames.Grub), 100);
            hermit.AddItemWithCost(Finder.GetItem(ItemNames.Longnail), new MultiCost(
                Cost.NewGeoCost(50) + Cost.NewGrubCost(1),
                Cost.NewGeoCost(50) + Cost.NewGrubCost(1)
            ));

            hermit2.AddItemWithCost(Finder.GetItem(ItemNames.Howling_Wraiths), Cost.NewGrubCost(1));
            hermit2.AddItemWithCost(Finder.GetItem(ItemNames.Abyss_Shriek), Cost.NewGrubCost(1) + Cost.NewGeoCost(500));
            hermit2.AddItemWithCost(new JournalEntryItem()
            {
                name = "FlukemarmEntry",
                playerDataName = nameof(PlayerData.killedFlukeMother).Substring(6),
                UIDef = new MsgUIDef()
                {
                    name = new BoxedString("Flukemarm Journal Entry"),
                    shopDesc = new BoxedString("I know what you're going to say and I'm going to stop you right there."),
                    sprite = new ItemChangerSprite("ShopIcons.JournalEntry")
                }
            }, 100); 
            hermit2.AddItemWithCost(Finder.GetItem(ItemNames.Mark_of_Pride), new MultiCost(
                Cost.NewGeoCost(50) + Cost.NewGrubCost(1),
                Cost.NewGeoCost(50) + Cost.NewGrubCost(1)
            ));

            AbstractItem tuner = Finder.GetItem(ItemNames.Godtuner);
            tuner.AddTag(new PDBoolShopReqTag() { fieldName = nameof(PlayerData.killedFlukeMother) });
            hermit3.AddItemWithCost(tuner, 1);

            yield return hermit;
            yield return hermit2;
            yield return hermit3;
        }
    }
}
