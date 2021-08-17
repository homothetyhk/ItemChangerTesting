using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;
using MenuChanger;
using MenuChanger.MenuElements;
using MenuChanger.MenuPanels;
using UnityEngine;

namespace ItemChangerTesting
{
    public class ItemChangerTestingMenuConstructor : ModeMenuConstructor
    {
        ItemChangerTestingMenu menu;

        public override BigButton GetModeButton(MenuPage modeMenu)
        {
            return menu.EntryButton;
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


        public static readonly Test[] Tests;

        public ItemChangerTestingMenu(MenuPage modePage)
        {
            TestSelectPage = new MenuPage("ItemChangerTesting Test Select Page", modePage);
            ArgsPage = new MenuPage("ItemChangerTesting Args Page", TestSelectPage);

            EntryButton = new BigButton(modePage, "ItemChanger Testing");
            EntryButton.Button.AddHideAndShowEvent(modePage, TestSelectPage);

            testViewer = new MultiGridItemPanel(TestSelectPage, 8, 3, 60f, 600f, new UnityEngine.Vector2(0f, 400f), Tests.Select((t, i) => GetButton(t, i)).ToArray());

            new MenuLabel(TestSelectPage, "Tests").MoveTo(new Vector2(0f, 480f));
            new MenuLabel(ArgsPage, "Item Flags").MoveTo(new Vector2(-400f, 480f));
            new MenuLabel(ArgsPage, "Start Flags").MoveTo(new Vector2(400f, 480f));

            startFlagMEF = new MenuElementFactory<StartFlags>(ArgsPage, args.StartFlags);
            itemFlagMEF = new MenuElementFactory<ItemFlags>(ArgsPage, args.ItemFlags);
            startFlagGIP = new GridItemPanel(ArgsPage, new Vector2(400f, 400f), 1, 100f, 300f, startFlagMEF.Elements);
            itemFlagGIP = new GridItemPanel(ArgsPage, new Vector2(-400f, 400f), 2, 100f, 300f, itemFlagMEF.Elements);
            startButton = new BigButton(ArgsPage, "Start Test");
            startButton.MoveTo(new Vector2(0f, -100f));
            startButton.OnClick += () => selectedTest.Start(args);
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


        static ItemChangerTestingMenu()
        {
            List<Test> tests = new List<Test>();
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

            Tests = tests.OrderBy(t => t.Priority).ThenBy(t => t.GetName()).ToArray();
        }

        public class RandomTest : Test
        {
            public override StartDef StartDef => throw new NotImplementedException();
            public override int Priority => int.MinValue;
            public override IEnumerable<AbstractPlacement> GetPlacements(TestArgs args)
            {
                throw new NotImplementedException();
            }

            public override void Start(TestArgs args)
            {
                Tests[new System.Random().Next(1, Tests.Length)].Start(args);
            }
        }
    }
}
