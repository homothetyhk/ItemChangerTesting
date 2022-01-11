namespace ItemChangerTesting.Tests
{
    public class CustomSkillTest : Test
    {
        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield return Finder.GetLocation("Elevator_Pass").Wrap().Add(Finder.GetItem("Left_Mothwing_Cloak"));
            yield return Finder.GetLocation("Mothwing_Cloak").Wrap().Add(Finder.GetItem("Right_Mantis_Claw"));
            yield return Finder.GetLocation(LocationNames.Wanderers_Journal_City_Storerooms).Wrap().Add(Finder.GetItem("Swim"));
            yield return Finder.GetLocation(LocationNames.Split_Mothwing_Cloak).Wrap().Add(Finder.GetItem("Focus"));
            yield return Finder.GetLocation("Salubra").Wrap().Add(Finder.GetItem("Right_Mothwing_Cloak")).Add(Finder.GetItem("Split_Shade_Cloak")).Add(Finder.GetItem(ItemNames.Left_Mothwing_Cloak))
                .Add(Finder.GetItem(ItemNames.Elevator_Pass));
        }
    }
}
