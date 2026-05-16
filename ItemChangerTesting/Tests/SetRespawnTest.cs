using ItemChanger.Deployers;
using ItemChanger.Tags;

namespace ItemChangerTesting.Tests;

internal class SetRespawnTest : Test
{
    public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
    {
        RespawnMarkerDeployer rm = new()
        {
            SceneName = SceneNames.Crossroads_38,
            X = 36.0f,
            Y = 4.0f,
            MapZone = GlobalEnums.MapZone.CROSSROADS,
            RespawnFacingRight = true,
        };
        ItemChangerMod.AddDeployer(rm);
        SetIBoolOnGiveTag tag = new() { Bool = rm.GetRespawnBool() };

        AbstractLocation l = Finder.GetLocation(LocationNames.Resting_Grounds_Stag);
        AbstractPlacement p = l.Wrap();
        AbstractItem i = args.Items.First();
        p.Add(i);
        l.AddTag(tag);

        yield return p;
    }

    public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.RestingGrounds_09, "left1");
}
