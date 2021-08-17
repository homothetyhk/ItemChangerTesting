using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;

namespace ItemChangerTesting.Tests
{
    class CollectorTest : Test
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Ruins2_11, "right1");

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation(LocationNames.Grub_Collector_1).Wrap().AddItems(args.Items);
            yield return Finder.GetLocation(LocationNames.Grub_Collector_2).Wrap().AddItem(Finder.GetItem(ItemNames.Geo_Rock_Abyss));
            yield return Finder.GetLocation(LocationNames.Grub_Collector_3).Wrap().AddItems(new[] { Finder.GetItem(ItemNames.Geo_Chest_Watcher_Knights), Finder.GetItem(ItemNames.Great_Slash) });
            yield return Finder.GetLocation(LocationNames.Collectors_Map).Wrap().AddItem(Finder.GetItem(ItemNames.Godtuner));
        }
    }
}
