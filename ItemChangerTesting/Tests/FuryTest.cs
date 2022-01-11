namespace ItemChangerTesting.Tests
{
    class FuryTest : Test
    {
        public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
        {
            yield break;
        }

        public override void Start(TestArgs args)
        {
            PlayerData.instance.gotCharm_6 = true;
            PlayerData.instance.gotCharm_27 = true;
            PlayerData.instance.maxHealth = PlayerData.instance.maxHealthBase = PlayerData.instance.health = 1;
            ItemChangerMod.CreateSettingsProfile();
            ItemChangerMod.AddDeployer(new SmallPlatform { SceneName = "Abyss_02", X = 128.3f, Y = 7f });
            ItemChangerMod.AddDeployer(new SmallPlatform { SceneName = "Abyss_02", X = 128.3f, Y = 11f });
            base.Start(args);
        }

    }
}
