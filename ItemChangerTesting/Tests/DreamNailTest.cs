using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;

namespace ItemChangerTesting.Tests
{
    class DreamNailTest : SimpleTest
    {
        public override StartDef StartDef => TransitionBasedStartDef.FromGate(SceneNames.RestingGrounds_04, "left1");
        public DreamNailTest() : base(LocationNames.Dream_Nail, "left1") { }
    }
}
