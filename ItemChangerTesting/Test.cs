using MenuChanger;

namespace ItemChangerTesting
{
    public abstract class Test
    {
        public virtual StartDef StartDef => new StartDef
        {
            SceneName = SceneNames.Tutorial_01,
            MapZone = 2,
            X = 35.5f,
            Y = 11.4f,
        };

        public virtual string GetName() => GetType().Name.FromCamelCase();
        public abstract IEnumerable<AbstractPlacement> GetPlacements(TestArgs args);
        public virtual int Priority => 0;

        public virtual void Start(TestArgs args)
        {
            ItemChangerMod.CreateSettingsProfile(overwrite: false);
            ItemChangerMod.ChangeStartGame(StartDef);
            ItemChangerMod.AddPlacements(GetPlacements(args));
            args.OnStart();
            MenuChangerMod.HideAllMenuPages();
            UIManager.instance.StartNewGame();
        }

        public static IEnumerable<AbstractItem> Repeat(AbstractItem item, int i)
        {
            yield return item;
            for (int j = 1; j < i; j++)
            {
                yield return item.Clone();
            }
        }
    }
}
