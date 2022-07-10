using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemChangerTesting.Tests
{
    class CHBridgeTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Mines_20, "left2");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Crystal_Heart).Wrap().Add(args.Items);
            yield return Finder.GetLocation(LocationNames.Start).Wrap().Add(Finder.GetItem(ItemNames.Left_Crystal_Heart));
        }

        public override void Start(TestArgs args)
        {
            base.Start(args);
            ItemChangerMod.AddTransitionOverride(new(SceneNames.Crossroads_04, "door1"), new Transition(SceneNames.Fungus2_14, "bot3"));
        }

    }
}
