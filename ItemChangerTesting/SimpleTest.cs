using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;

namespace ItemChangerTesting
{
    public abstract class SimpleTest : Test
    {
        public readonly AbstractLocation location;
        public readonly string entryGateName;

        public SimpleTest(string location, string entryGateName)
        {
            this.location = Finder.GetLocation(location);
            this.entryGateName = entryGateName;
        }

        public override StartDef StartDef => TransitionBasedStartDef.FromGate(location.sceneName, entryGateName);

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return location.Wrap().AddItems(args.Items);
        }
    }
}
