using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;
using ItemChanger.Items;

namespace ItemChangerTesting
{
    public class TestArgs
    {
        public ItemFlags ItemFlags = new ItemFlags();
        public StartFlags StartFlags = new StartFlags();

        static TestArgs()
        {
            string[] items = ItemNames.ToArray();
            georocks = items.Where(i => i.StartsWith("Geo_Rock")).ToArray();
        }

        static string[] georocks;
        public void OnStart()
        {
            AbstractPlacement start = Finder.GetLocation("Start").Wrap();
            start.Location.name = "Silent_Start";
            ((ItemChanger.Locations.StartLocation)start.Location).MessageType = MessageType.None;

            if (StartFlags.IncreasedNailDamage)
            {
                PlayerData.instance.nailDamage = 500;
            }
            if (StartFlags.Movement)
            {
                start.AddItem(Finder.GetItem(ItemNames.Mothwing_Cloak));
                start.AddItem(Finder.GetItem(ItemNames.Mantis_Claw));
                start.AddItem(Finder.GetItem(ItemNames.Crystal_Heart));
                start.AddItem(Finder.GetItem(ItemNames.Monarch_Wings));
                start.AddItem(Finder.GetItem(ItemNames.Shade_Cloak));
                start.AddItem(Finder.GetItem(ItemNames.Ismas_Tear));
            }
            if (StartFlags.DreamNail)
            {
                start.AddItem(Finder.GetItem(ItemNames.Dream_Nail));
            }
            if (StartFlags.Spells)
            {
                start.AddItem(Finder.GetItem(ItemNames.Vengeful_Spirit));
                start.AddItem(Finder.GetItem(ItemNames.Shade_Soul));
                start.AddItem(Finder.GetItem(ItemNames.Desolate_Dive));
                start.AddItem(Finder.GetItem(ItemNames.Descending_Dark));
                start.AddItem(Finder.GetItem(ItemNames.Howling_Wraiths));
                start.AddItem(Finder.GetItem(ItemNames.Abyss_Shriek));
                start.AddItem(Finder.GetItem(ItemNames.Soul_Totem));
            }
            if (StartFlags.StartGeo)
            {
                start.AddItem(new AddGeoItem { amount = 10000, name = "10000 geo" });
            }

            ItemChangerMod.AddPlacements(new[] { start });
        }
        public IEnumerable<AbstractItem> Items
        {
            get
            {
                if (ItemFlags.Charm)
                {
                    yield return Finder.GetItem(ItemNames.Grubsong);
                }
                if (ItemFlags.BigItem)
                {
                    yield return Finder.GetItem(ItemNames.Cyclone_Slash);
                }
                if (ItemFlags.Grub)
                {
                    yield return Finder.GetItem(ItemNames.Grub);
                }
                if (ItemFlags.Lore)
                {
                    yield return Finder.GetItem(ItemNames.Lore_Tablet_Kings_Pass_Focus);
                }
                if (ItemFlags.GeoRock)
                {
                    yield return Finder.GetItem(georocks[new Random().Next(georocks.Length)]);
                }
                if (ItemFlags.Lore)
                {
                    yield return Finder.GetItem(ItemNames.Lore_Tablet_Fungal_Wastes_Hidden);
                }
                if (ItemFlags.Lore)
                {
                    yield return Finder.GetItem(ItemNames.Lore_Tablet_City_Entrance);
                }
            }
        }
    }

    public class ItemFlags
    {
        public bool Charm = true;
        public bool BigItem = true;
        public bool Grub = true;
        public bool GeoRock = true;
        public bool Lore = true;
    }

    public class StartFlags
    {
        public bool IncreasedNailDamage = true;
        public bool Movement = true;
        public bool DreamNail = true;
        public bool Spells = true;
        public bool StartGeo = true;
    }
}
