using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;
using ItemChanger.Items;

namespace ItemChangerTesting.Tests
{
    class BrummFlameTest : SimpleTest
    {
        public BrummFlameTest() : base(ItemChanger.LocationNames.Grimmkin_Flame_Brumm, "left1") { }

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            foreach (var p in base.GetPlacements(args)) yield return p;
            yield return Finder.GetLocation(LocationNames.Start).Wrap()
                .AddItem(new EquippedCharmItem { charmNum = 40 })
                .AddItem(new IntItem
                {
                    amount = 3,
                    fieldName = nameof(PlayerData.grimmChildLevel),
                });
        }
    }
}
