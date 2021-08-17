using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;
using ItemChanger.Items;

namespace ItemChangerTesting.Tests
{
    class GrimmkinTest : SimpleTest
    {
        public GrimmkinTest() : base(ItemChanger.LocationNames.Grimmkin_Flame_Greenpath, "top1") { }

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            foreach (var p in base.GetPlacements(args)) yield return p;
            yield return Finder.GetLocation(LocationNames.Start).Wrap()
                .AddItem(new EquippedCharmItem { charmNum = 40 });
        }
    }
}
