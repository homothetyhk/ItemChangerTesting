using ItemChanger.Placements;
using ItemChanger.StartDefs;

namespace ItemChangerTesting.Tests
{
    class SheoTest : Test
    {
        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            AutoPlacement p = (AutoPlacement)Finder.GetLocation(LocationNames.Great_Slash).Wrap();
            p.Cost = Cost.NewGeoCost(1000);
            p.Add(args.Items);
            yield return p;
        }

        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.Room_nailmaster_02, "left1");

        public override void Start(TestArgs args)
        {
            PlayerData.instance.nailsmithSpared = true;
            base.Start(args);
        }

    }
}
