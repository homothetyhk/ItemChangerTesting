using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;
using MenuChanger;

namespace ItemChangerTesting
{
    public abstract class Test
    {
        public virtual StartDef StartDef => new StartDef
        {
            startSceneName = SceneNames.Tutorial_01,
            mapZone = 2,
            startX = 35.5f,
            startY = 11.4f,
        };

        public virtual string GetName() => GetType().Name.FromCamelCase();
        public abstract IEnumerable<AbstractPlacement> GetPlacements(TestArgs args);
        public virtual int Priority => 0;

        public virtual void Start(TestArgs args)
        {
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
