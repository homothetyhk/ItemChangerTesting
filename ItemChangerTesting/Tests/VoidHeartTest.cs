using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;

namespace ItemChangerTesting.Tests
{
    class VoidHeartTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Abyss_15, "top1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Void_Heart).Wrap().AddItems(args.Items);
        }
    }
}
