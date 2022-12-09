﻿using GlobalEnums;
using ItemChanger.Locations;
using ItemChanger.Placements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemChangerTesting.Tests
{
    /// <summary>
    /// Tests that custom shop locations can properly control the facing-direction of the NPC and that
    /// the shop opens on the correct side of the screen. Also tests that multiple shops can exist in
    /// the same scene on different NPCs.
    /// </summary>
    class CustomShopDirtmouthTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate("Town", "door_mapper", (int)MapZone.TOWN);

        public override void Start(TestArgs args)
        {
            base.Start(args);
        }

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            ShopPlacement elderbugNeutral = new CustomShopLocation()
            {
                name = "Elderbug_Shop",
                sceneName = "Town",
                objectName = "Elderbug",
                fsmName = "npc_control",
                facingDirection = FacingDirection.Auto
            }.Wrap() as ShopPlacement;
            elderbugNeutral.Add(Finder.GetItem(ItemNames.Godtuner));

            ShopPlacement gravediggerFacingLeft = new CustomShopLocation()
            {
                name = "Gravedigger_Shop",
                sceneName = "Town",
                objectName = "Gravedigger NPC",
                fsmName = "npc_control",
                facingDirection = FacingDirection.Left

            }.Wrap() as ShopPlacement;
            gravediggerFacingLeft.Add(Finder.GetItem(ItemNames.Collectors_Map));

            ShopPlacement tisoFacingRight = new CustomShopLocation()
            {
                name = "Tiso_Shop",
                sceneName = "Town",
                objectName = "Tiso Town NPC",
                fsmName = "npc_control",
                facingDirection = FacingDirection.Right
            }.Wrap() as ShopPlacement;
            tisoFacingRight.Add(Finder.GetItem(ItemNames.World_Sense));

            yield return elderbugNeutral;
            yield return gravediggerFacingLeft;
            yield return tisoFacingRight;
        }
    }
}