using MenuChanger;
using MenuChanger.Extensions;
using MenuChanger.MenuElements;
using MenuChanger.MenuPanels;
using UnityEngine;

namespace ItemChangerTesting
{
    public class ItemChangerTestingMenuConstructor : ModeMenuConstructor
    {
        ItemChangerTestingMenu menu;

        public override bool TryGetModeButton(MenuPage modeMenu, out BigButton button)
        {
            button = menu.EntryButton;
            return true;
        }

        public override void OnEnterMainMenu(MenuPage modeMenu)
        {
            menu = new ItemChangerTestingMenu(modeMenu);
        }

        public override void OnExitMainMenu()
        {
            menu = null;
        }
    }

    public class ItemChangerTestingMenu
    {
        public static event Func<IEnumerable<Test>> TestInjectors;

        public BigButton EntryButton;
        public MenuPage TestSelectPage;
        public MenuPage ArgsPage;

        OrderedItemViewer testViewer;
        Test selectedTest;

        TestArgs args = new TestArgs();
        MenuElementFactory<ItemFlags> itemFlagMEF;
        MenuElementFactory<StartFlags> startFlagMEF;
        GridItemPanel itemFlagGIP;
        GridItemPanel startFlagGIP;
        BigButton startButton;


        readonly Test[] Tests;

        public ItemChangerTestingMenu(MenuPage modePage)
        {
            Tests = GetTests();

            TestSelectPage = new MenuPage("ItemChangerTesting Test Select Page", modePage);
            ArgsPage = new MenuPage("ItemChangerTesting Args Page", TestSelectPage);

            EntryButton = new BigButton(modePage, "ItemChanger Testing");
            EntryButton.AddHideAndShowEvent(modePage, TestSelectPage);

            testViewer = new MultiGridItemPanel(TestSelectPage, 12, 3, 60f, 600f, new Vector2(0f, 400f), Tests.Select((t, i) => GetButton(t, i)).ToArray());

            new MenuLabel(TestSelectPage, "Tests").MoveTo(new Vector2(0f, 480f));
            new MenuLabel(ArgsPage, "Item Flags").MoveTo(new Vector2(-400f, 480f));
            new MenuLabel(ArgsPage, "Start Flags").MoveTo(new Vector2(400f, 480f));

            itemFlagMEF = new MenuElementFactory<ItemFlags>(ArgsPage, args.ItemFlags);
            itemFlagGIP = new GridItemPanel(ArgsPage, new Vector2(-400f, 400f), 2, 100f, 300f, true, itemFlagMEF.Elements);

            startFlagMEF = new MenuElementFactory<StartFlags>(ArgsPage, args.StartFlags);
            startFlagGIP = new GridItemPanel(ArgsPage, new Vector2(400f, 400f), 1, 100f, 300f, true, startFlagMEF.Elements);
            
            startButton = new BigButton(ArgsPage, "Start Test");
            startButton.MoveTo(new Vector2(0f, -100f));
            startButton.OnClick += () => selectedTest.Start(args);
            startFlagGIP.SetNeighbor(Neighbor.Down, startButton);
            startButton.SymSetNeighbor(Neighbor.Up, itemFlagGIP);
            startButton.SymSetNeighbor(Neighbor.Down, ArgsPage.backButton);
        }

        public SmallButton GetButton(Test t, int index)
        {
            SmallButton button = new SmallButton(TestSelectPage, $"[{index}] {t.GetName()}");
            button.OnClick += () => SelectTest(t);
            return button;
        }

        public void SelectTest(Test t)
        {
            selectedTest = t;
            TestSelectPage.Hide();
            ArgsPage.Show();
        }


        static Test[] GetTests()
        {
            List<Test> tests = new();
            IEnumerable<Type> types = typeof(Test).Assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Test)));
            foreach (var type in types)
            {
                try
                {
                    if (type.GetConstructor(Array.Empty<Type>())?.Invoke(Array.Empty<object>()) is Test t) tests.Add(t);
                }
                catch (Exception e)
                {
                    Modding.Logger.LogError($"Failed to instantiate ItemChangerTesting.Test of type {type.Name}:\n{e}");
                }
            }
            if (TestInjectors != null)
            {
                foreach (Delegate d in TestInjectors.GetInvocationList())
                {
                    try
                    {
                        tests.AddRange(((Func<IEnumerable<Test>>)d)());
                    }
                    catch (Exception e) 
                    {
                        Modding.Logger.LogError($"Failed to load external tests for ItemChangerTesting:\n{e}");
                    }
                }
            }

            return tests.OrderBy(t => t.Priority).ThenBy(t => t.GetName()).ToArray();
        }
    }
}
