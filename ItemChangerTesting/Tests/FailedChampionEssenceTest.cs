using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemChangerTesting.Tests
{
    class FailedChampionEssenceTest : SimpleTest
    {
        public FailedChampionEssenceTest() : base(ItemChanger.LocationNames.Boss_Essence_Failed_Champion, "right1") { }

        public override void Start(TestArgs args)
        {
            base.Start(args);
            PlayerData.instance.falseKnightDefeated = true;
            PlayerData.instance.falseKnightDreamDefeated = true;
        }
    }
}
