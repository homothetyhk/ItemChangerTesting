using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemChangerTesting.Tests
{
    internal class FlukenestTest : SimpleTest
    {
        public FlukenestTest() : base(LocationNames.Flukenest, "right1") { }

        /*
        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Flukenest).Wrap().Add(Finder.GetItem(ItemNames.Geo_Rock_Outskirts420));
        }
        */
    }
}
