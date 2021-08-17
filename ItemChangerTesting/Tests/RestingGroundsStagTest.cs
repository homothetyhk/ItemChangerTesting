using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;
using ItemChanger.Locations;
using ItemChanger.Placements;

namespace ItemChangerTesting.Tests
{
    public class RestingGroundsStagTest : SimpleTest
    {
        public RestingGroundsStagTest() : base(LocationNames.Resting_Grounds_Stag, "left1") { }
        /*
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.RestingGrounds_09, "left1");

        public override IEnumerable<AbstractPlacement> GetPlacements()
        {
            yield return new MutablePlacement
            {
                location = Finder.GetLocation(LocationNames.Resting_Grounds_Stag) as ContainerLocation,
            }.AddItems(StandardItems);
        }
        */
    }
}
