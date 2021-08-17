using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;

namespace ItemChangerTesting.Tests
{
    class GrubTest : SimpleTest
    {
        public GrubTest() : base(ItemChanger.LocationNames.Grub_Crystal_Peak_Below_Chest, "top1") { }

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Grub_Crystal_Peak_Below_Chest).Wrap().AddItem(Finder.GetItem(ItemNames.Grub));
        }

    }
}
