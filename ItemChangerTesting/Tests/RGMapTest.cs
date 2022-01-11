namespace ItemChangerTesting.Tests
{
    class RGMapTest : SimpleTest
    {
        public RGMapTest() : base(LocationNames.Resting_Grounds_Map, "left1")
        {
        }
        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            foreach (var p in base.GetPlacements(args))
            {
                if (p is ItemChanger.Placements.ISingleCostPlacement iscp) iscp.Cost = Cost.NewGeoCost(56);
                yield return p;
            }
        }
    }
}
