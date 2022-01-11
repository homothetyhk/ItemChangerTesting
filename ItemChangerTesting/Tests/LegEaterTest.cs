using HutongGames.PlayMaker;
using ItemChanger.Extensions;
using ItemChanger.FsmStateActions;
using ItemChanger.Placements;

namespace ItemChangerTesting.Tests
{
    class LegEaterTest : SimpleTest
    {
        public LegEaterTest() : base(LocationNames.Leg_Eater, "left1") { }

        public override void Start(TestArgs args)
        {
            //On.PlayMakerFSM.OnEnable += this.PlayMakerFSM_OnEnable;
            var pd = PlayerData.instance;
            pd.gotCharm_23 = pd.gotCharm_24 = pd.gotCharm_25 = true;
            pd.brokenCharm_23 = true;
            //pd.fragileGreed_unbreakable = pd.fragileHealth_unbreakable = pd.fragileStrength_unbreakable = true;

            base.Start(args);
        }

        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            var p = Finder.GetLocation(LocationNames.Leg_Eater).Wrap().Add(args.Items) as ShopPlacement;
            p.defaultShopItems = DefaultShopItems.LegEaterRepair;
            yield return p;
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            orig(self);
            if (self.gameObject.scene.name != SceneNames.Fungus2_26) return;
            foreach (FsmState state in self.FsmStates)
            {
                state.AddFirstAction(new Lambda(() => Modding.Logger.Log($"{self.gameObject.name}-{self.FsmName}[{state.Name}]")));
            }

        }
    }
}
