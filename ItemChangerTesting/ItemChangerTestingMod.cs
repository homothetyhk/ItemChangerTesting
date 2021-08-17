using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modding;
using MenuChanger;
using System.Reflection;
using System.IO;

namespace ItemChangerTesting
{
    public class ItemChangerTestingMod : Mod
    {
        public override void Initialize()
        {
            base.Initialize();
            ModeMenu.AddMode(new ItemChangerTestingMenuConstructor());
        }

        public override string GetVersion()
        {
            return $"{ItemChangerTestingMenu.Tests.Length} Tests. SHA1: {GetSHA1().Substring(0, 4)}";
        }

        public static string GetSHA1()
        {
            Assembly a = typeof(ItemChangerTestingMod).Assembly;
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            using (var sr = File.OpenRead(a.Location))
            {
                return Convert.ToBase64String(sha1.ComputeHash(sr));
            }
        }
    }
}
