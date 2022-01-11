using ItemChanger.Placements;

namespace ItemChangerTesting.Tests
{
    public class RestingGroundsStagTest : SimpleTest
    {
        public RestingGroundsStagTest() : base(LocationNames.Resting_Grounds_Stag, "left1") { }

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            foreach (var p in base.GetPlacements(args))
            {
                (p as ISingleCostPlacement).Cost = Cost.NewGeoCost(1000);
                yield return p;
            }
        }

        /*
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.RestingGrounds_09, "left1");

        public override IEnumerable<AbstractPlacement> GetPlacements()
        {
            yield return new MutablePlacement
            {
                location = Finder.GetLocation(LocationNames.Resting_Grounds_Stag) as ContainerLocation,
            }.Add(StandardItems);
        }
        */
    }
}
